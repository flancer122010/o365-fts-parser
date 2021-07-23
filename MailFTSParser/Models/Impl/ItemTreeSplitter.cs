using MailFTSParsers.Enums;
using MailFTSParsers.Models.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models
{
    class ItemTreeSplitter : IItemTreeBuilder, IPropertyBuilder
    {
        private SplittedItemInfo info = new SplittedItemInfo();

        private TopItemProps topProps;

        private IPropertyBuilder propColl;

        private List<byte> recipients;

        private List<SplittedAttachInfo> attaches;

        private AttachPropConverter attach;

        private List<byte> embedded;

        private int embeddedLevel;

        private bool TopLevel
        {
            get
            {
                return embeddedLevel == 0;
            }
        }

        internal ItemTreeSplitter()
        {
            topProps = new TopItemProps();
            propColl = topProps;
        }

        internal SplittedItemInfo GetSplittedItemInfo()
        {
            info.Recipients = recipients?.ToArray();
            info.Attaches = attaches?.ToArray();
            return info;
        }

        public void Prop(byte[] allData, PropertyId PropertyId, byte[] value, IValueParser parser)
        {
            if (PropertyId.Tag != 1075183619)
            {
                if (propColl == null)
                {
                    throw new Exception("Unexpected error");
                }
                propColl.Prop(allData, PropertyId, value, parser);
            }
        }

        public void PropMV(byte[] allData, PropertyId PropertyId, byte[][] value, IValueParser parser)
        {
            if (propColl == null)
            {
                throw new Exception("Unexpected error");
            }
            propColl.PropMV(allData, PropertyId, value, parser);
        }

        public void SetItemProps()
        {
            if (topProps != null)
            {
                TopItemProps topProps = this.topProps;
                topProps = null;
                propColl = null;
                info.ItemProps = topProps.GetProps();

                if(topProps.HtmlBody != null)
                {
                    info.Body = topProps.HtmlBody;
                    info.BodyType = BodyType.Html;
                } else if(topProps.RtfBody != null)
                {
                    info.Body = topProps.RtfBody;
                    info.BodyType = BodyType.RichText;
                } else if(topProps.PlainBody != null)
                {
                    info.Body = topProps.PlainBody;
                    info.BodyType = BodyType.RichText;
                }
            }
        }

        public void StartRecipient()
        {
            if (TopLevel)
            {
                if (recipients == null)
                {
                    recipients = new List<byte>();
                }
                recipients.AddRange(Markers.StartRecipBytes);
                propColl = new PropAppender(recipients);
            }
            else
            {
                embedded.AddRange(Markers.StartRecipBytes);
            }
        }

        public void EndRecipient()
        {
            if (TopLevel)
            {
                propColl = null;
                recipients.AddRange(Markers.EndToRecipBytes);
            }
            else
            {
                embedded.AddRange(Markers.EndToRecipBytes);
            }
        }

        public void StartAttach()
        {
            if (TopLevel)
            {
                if (attaches == null)
                {
                    attaches = new List<SplittedAttachInfo>();
                }
                propColl = (attach = new AttachPropConverter());
            }
            else
            {
                embedded.AddRange(Markers.NewAttachBytes);
            }
        }

        public void EndAttach()
        {
            if (TopLevel)
            {
                SplittedAttachInfo info = attach.GetInfo();
                attaches.Add(info);
                propColl = (attach = null);
            }
            else
            {
                embedded.AddRange(Markers.EndAttachBytes);
            }
        }

        public void StartEmbeddedItem()
        {
            if (TopLevel)
            {
                embedded = new List<byte>();
                propColl = new PropAppender(embedded);
            }
            else
            {
                embedded.AddRange(Markers.StartEmbedBytes);
            }
            embeddedLevel++;
        }

        public void EndEmbeddedItem()
        {
            embeddedLevel--;
            if (TopLevel)
            {
                SplittedAttachInfo info = attach.GetInfo();
                info.Content = embedded.ToArray();
                attaches.Add(info);
                embedded = null;
                propColl = (attach = null);
            }
            else
            {
                embedded.AddRange(Markers.EndEmbedBytes);
                embedded.AddRange(Markers.EndAttachBytes);
            }
        }
    }
}

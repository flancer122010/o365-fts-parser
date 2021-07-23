using MailFTSParsers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models.Impl
{
    public class ItemInfoBuilder : IItemBuilder
    {
        private Stack<ItemInfoInfo> items = new Stack<ItemInfoInfo>();

        private ItemInfoInfo root;

        private ItemInfoInfo current;

        public ItemInfo Info
        {
            get
            {
                return root.Info;
            }
        }

        internal ItemInfoBuilder()
        {
            current = new ItemInfoInfo();
            root = current;
        }

        public void SetItemProps(IDictionary<PropertyId, object> props)
        {
            object obj = ExtractProp(props, new PropertyId(MAPIProps.PR_BODY));
            if (obj != null)
            {
                string s = (string)obj;
                current.SetBody(Encoding.Unicode.GetBytes(s), BodyType.PlainText);
            }
            else
            {
                obj = ExtractProp(props, new PropertyId(MAPIProps.PR_HTML));
                if (obj != null)
                {
                    current.SetBody((byte[])obj, BodyType.Html);
                }
                else
                {
                    obj = ExtractProp(props, new PropertyId(MAPIProps.PR_RTF_COMPRESSED));
                    if (obj != null)
                    {
                        current.SetBody((byte[])obj, BodyType.RichText);
                    }
                }
            }
            obj = ExtractProp(props, new PropertyId(MAPIProps.PR_SUBJECT));
            if(obj != null)
            {
                current.Info.Subject = (string)obj;
            }
            obj = ExtractProp(props, new PropertyId(MAPIProps.PR_MESSAGE_CLASS));
            if (obj != null)
            {
                current.Info.ItemClass = (string)obj;
            }
            obj = ExtractProp(props, new PropertyId(MAPIProps.PR_HASATTACH));
            if (obj != null)
            {
                current.Info.HasAttachments = (bool)obj;
            }
            obj = ExtractProp(props, new PropertyId(MAPIProps.PR_MESSAGE_SIZE));
            if(obj != null)
            {
                current.Info.Size = (long)obj;
            }
            obj = ExtractProp(props, new PropertyId(MAPIProps.PR_CREATION_TIME));
            if (obj != null)
            {
                current.Info.CreatedTime = ((FileTime)obj).ToDateTime();
            }
            obj = ExtractProp(props, new PropertyId(MAPIProps.PidTagSenderSmtpAddress));
            if (obj != null)
            {
                current.Info.EmailAddress = obj.ToString();
            }
            obj = ExtractProp(props, new PropertyId(MAPIProps.PR_SENDER_NAME));
            if (obj != null)
            {
                current.Info.DisplayName = obj.ToString();
            }
            obj = ExtractProp(props, new PropertyId(MAPIProps.PR_MESSAGE_FLAGS));
            if (obj != null)
            {
                current.Info.Flag = (int)obj;
            }
            current.Info.Properties = InternalProps.Skip(props);
            obj = ExtractProp(props, new PropertyId(MAPIProps.PR_APPOINTMENT_END_DATE));
            if(obj != null)
            {
                current.Info.EndTime = ((FileTime)obj).ToDateTime();
            }
            
            obj = ExtractProp(props, new PropertyId(MAPIProps.PR_APPOINTMENT_START_DATE));
            if (obj != null)
            {
                current.Info.StartTime = ((FileTime)obj).ToDateTime();
            }

            obj = ExtractProp(props, new PropertyId(MAPIProps.PR_LAST_MODIFICATION_TIME));
            if (obj != null)
            {
                current.Info.LastModifiedTime = ((FileTime)obj).ToDateTime();
            }
            obj = ExtractProp(props, new PropertyId(MAPIProps.PR_SUBMITTED_TIME));
            if (obj != null)
            {
                current.Info.SubmittedTime = ((FileTime)obj).ToDateTime();
            }
            obj = ExtractProp(props, new PropertyId(MAPIProps.PR_IMPORTANCE));
            if (obj != null)
            {
                current.Info.Importance = ((int)obj);
            }

            obj = ExtractProp(props, new PropertyId(MAPIProps.PR_SENSITIVITY));
            if (obj != null)
            {
                current.Info.Importance = ((int)obj);
            }

            obj = ExtractProp(props, new PropertyId(MAPIProps.PR_PRIORITY));
            if (obj != null)
            {
                current.Info.Priority = ((int)obj);
            }
        }

        private static object ExtractProp(IDictionary<PropertyId, object> props, PropertyId PropertyId)
        {
            if (props.TryGetValue(PropertyId, out object result))
            {
                //props.Remove(PropertyId);
                return result;
            }
            return null;
        }

        public void AddRecipient(IDictionary<PropertyId, object> props)
        {
            current.AddRecipient(RecipientCollector.Convert(props));
        }

        public void AddAttach(IDictionary<PropertyId, object> props)
        {
            object obj = ExtractProp(props, new PropertyId(MAPIProps.PR_ATTACH_DATA_BIN));
            if (obj == null)
            {
                obj = ExtractProp(props, new PropertyId(MAPIProps.PR_ATTACH_DATA_OBJ));
            }
            AttachInfo attachInfo = GetAttachInfo(props);
            attachInfo.Content = (byte[])obj;
            current.AddAttach(attachInfo);
        }

        public void AddEmbeddedItem(IDictionary<PropertyId, object> props)
        {
            ItemInfoInfo itemInfoInfo = new ItemInfoInfo();
            AttachInfo attachInfo = GetAttachInfo(props);
            attachInfo.Embedded = itemInfoInfo.Info;
            current.AddAttach(attachInfo);
            items.Push(current);
            current = itemInfoInfo;
        }

        private static AttachInfo GetAttachInfo(IDictionary<PropertyId, object> props)
        {
            AttachInfo attachInfo = new AttachInfo();
            attachInfo.Fill(props);
            return attachInfo;
        }

        public void EndEmbeddedItem()
        {
            if(items.Count > 0)
                current = items.Pop();
        }
    }

}

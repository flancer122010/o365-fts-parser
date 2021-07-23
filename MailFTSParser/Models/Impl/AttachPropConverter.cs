using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models.Impl
{
    class AttachPropConverter : PropertyConverter
    {
        private List<byte> allProps = new List<byte>();

        private byte[] content;

        internal SplittedAttachInfo GetInfo()
        {
            return new SplittedAttachInfo
            {
                SerializedProps = allProps.ToArray(),
                Content = content
            };
        }

        public override void Prop(byte[] stream, PropertyId propertyId, byte[] value, IValueParser parser)
        {
            if (propertyId == new PropertyId(MAPIProps.PR_ATTACH_DATA_BIN) || propertyId == new PropertyId(MAPIProps.PR_ATTACH_DATA_OBJ))
            {
                content = value;
            }
            else
            {
                base.Prop(stream, propertyId, value, parser);
                allProps.AddRange(stream);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models.Impl
{
    class TopItemProps : IPropertyBuilder
    {
        private List<byte> props = new List<byte>();

        private byte[] plainBody;

        private byte[] rtfBody;

        private byte[] htmlBody;

        public byte[] PlainBody
        {
            get
            {
                return plainBody;
            }
        }

        public byte[] RtfBody
        {
            get
            {
                return rtfBody;
            }
        }

        public byte[] HtmlBody
        {
            get
            {
                return htmlBody;
            }
        }

        public void Prop(byte[] stream, PropertyId propertyId, byte[] value, IValueParser parser)
        {
            if (propertyId == new PropertyId(MAPIProps.PR_BODY))
            {
                string s = (string)parser.GetValue(value);
                plainBody = Encoding.Unicode.GetBytes(s);
            }
            else if (propertyId == new PropertyId(MAPIProps.PR_RTF_COMPRESSED))
            {
                rtfBody = (byte[])parser.GetValue(value);
            }
            else if (propertyId == new PropertyId(MAPIProps.PR_HTML))
            {
                htmlBody = (byte[])parser.GetValue(value);
            }
            else
            {
                props.AddRange(stream);
            }
        }

        public void PropMV(byte[] stream, PropertyId propertyId, byte[][] value, IValueParser parser)
        {
            props.AddRange(stream);
        }

        internal byte[] GetProps()
        {
            return props.ToArray();
        }
    }

}

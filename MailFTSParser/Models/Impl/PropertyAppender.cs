using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models.Impl
{
    class PropAppender : IPropertyBuilder
    {
        private readonly List<byte> data;

        public PropAppender(List<byte> data)
        {
            data = this.data;
        }

        public void Prop(byte[] stream, PropertyId propertyId, byte[] value, IValueParser parser)
        {
            data.AddRange(stream);
        }

        public void PropMV(byte[] stream, PropertyId propertyId, byte[][] value, IValueParser parser)
        {
            data.AddRange(stream);
        }
    }
}

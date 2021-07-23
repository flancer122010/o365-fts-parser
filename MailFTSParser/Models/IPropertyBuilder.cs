using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models
{
    interface IPropertyBuilder
    {
        void Prop(byte[] stream, PropertyId propertyId, byte[] propertyValue, IValueParser parser);

        void PropMV(byte[] stream, PropertyId propertyId, byte[][] propertyValue, IValueParser parser);
    }
}

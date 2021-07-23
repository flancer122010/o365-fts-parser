using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models
{
    public class PropertyConverter : IPropertyBuilder
    {
        private readonly IDictionary<PropertyId, object> _properties;

        internal IDictionary<PropertyId, object> Props => _properties;

        internal PropertyConverter()
        {
            _properties = new Dictionary<PropertyId, object>();
        }

        public virtual void Prop(byte[] stream, PropertyId propertyId, byte[] value, IValueParser parser)
        {
            _properties[propertyId] = parser.GetValue(value);
        }

        public virtual void PropMV(byte[] stream, PropertyId propertyId, byte[][] value, IValueParser parser)
        {
            object[] array = new object[value.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = parser.GetValue(value[i]);
            }
            _properties[propertyId] = array;
        }
    }
}

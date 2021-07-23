using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models.Impl
{
    public class FullItemTreeBuilder : IItemTreeBuilder, IPropertyBuilder
    {
        private readonly IItemBuilder builder;

        private IDictionary<PropertyId, object> props = new Dictionary<PropertyId, object>();

        internal FullItemTreeBuilder(IItemBuilder builder)
        {
            this.builder = builder;
        }

        private void Prop(PropertyId PropertyId, object value)
        {
            if (PropertyId.Tag != 1075183619)
            {
                if (props == null)
                {
                    throw new Exception("UnexpectedProperty");
                }
                props[PropertyId] = value;
            }
        }

        public void Prop(byte[] stream, PropertyId prop, byte[] value, IValueParser parser)
        {
            Prop(prop, parser.GetValue(value));
        }

        public void PropMV(byte[] stream, PropertyId prop, byte[][] values, IValueParser parser)
        {
            object[] array = new object[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                array[i] = parser.GetValue(values[i]);
            }
            Prop(prop, array);
        }

        private IDictionary<PropertyId, object> GetProps()
        {
            IDictionary<PropertyId, object> props = this.props;
            this.props = null;
            return props;
        }

        private void InitProps()
        {
            props = new Dictionary<PropertyId, object>();
        }

        public void SetItemProps()
        {
            builder.SetItemProps(GetProps());
        }

        public void StartRecipient()
        {
            InitProps();
        }

        public void EndRecipient()
        {
            builder.AddRecipient(GetProps());
        }

        public void StartAttach()
        {
            InitProps();
        }

        public void EndAttach()
        {
           builder.AddAttach(GetProps());
        }

        public void StartEmbeddedItem()
        {
            builder.AddEmbeddedItem(GetProps());
            InitProps();
        }

        public void EndEmbeddedItem()
        {
            builder.EndEmbeddedItem();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailFTSParsers.Models.Impl;
namespace MailFTSParsers.Models.Impl
{
    public class PropertyBuilder : IItemTreeBuilder, IPropertyBuilder
    {
        public PropertyConverter Converter
        {
            get;
            set;
        }

        public IDictionary<PropertyId, object> Props
        {
            get { return Converter.Props; }
        }

        public PropertyBuilder()
        {
            Converter = new PropertyConverter();
        }

        public virtual void Prop(byte[] stream, PropertyId propertyId, byte[] value, IValueParser parser)
        {
            Converter.Prop(stream, propertyId, value, parser);
        }

        public virtual void PropMV(byte[] stream, PropertyId propertyId, byte[][] value, IValueParser parser)
        {
            Converter.PropMV(stream, propertyId, value, parser);
        }

        public virtual void SetItemProps()
        {
        }

        public virtual void StartRecipient()
        {
        }

        public virtual void EndRecipient()
        {
        }

        public virtual void StartAttach()
        {
        }

        public virtual void EndAttach()
        {
        }

        public virtual void StartEmbeddedItem()
        {
        }

        public virtual void EndEmbeddedItem()
        {
        }
    }
}

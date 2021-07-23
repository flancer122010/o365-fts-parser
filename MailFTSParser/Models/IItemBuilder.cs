using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models
{
    public interface IItemBuilder
    {
        void SetItemProps(IDictionary<PropertyId, object> props);

        void AddRecipient(IDictionary<PropertyId, object> props);

        void AddAttach(IDictionary<PropertyId, object> props);

        void AddEmbeddedItem(IDictionary<PropertyId, object> props);

        void EndEmbeddedItem();
    }
}

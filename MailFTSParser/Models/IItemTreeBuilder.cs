using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models
{
    interface IItemTreeBuilder : IPropertyBuilder
    {
        void SetItemProps();

        void StartRecipient();

        void EndRecipient();

        void StartAttach();

        void EndAttach();

        void StartEmbeddedItem();

        void EndEmbeddedItem();
    }
}

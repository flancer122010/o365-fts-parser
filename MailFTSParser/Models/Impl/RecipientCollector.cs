using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models.Impl
{
    public class RecipientCollector : PropertyBuilder
    {
        private readonly List<SortedList<uint, object>> recipients = new List<SortedList<uint, object>>();

        internal IReadOnlyList<SortedList<uint, object>> Recipients
        {
            get { return recipients; }
        }

        public RecipientCollector()
        {
            base.Converter = null;
        }

        public override void SetItemProps()
        {
        }

        public override void StartRecipient()
        {
            base.Converter = new PropertyConverter();
        }

        public override void EndRecipient()
        {
            recipients.Add(Convert(base.Converter.Props));
            base.Converter = null;
        }

        internal static SortedList<uint, object> Convert(IDictionary<PropertyId, object> props)
        {
            SortedList<uint, object> sortedList = new SortedList<uint, object>();
            foreach (KeyValuePair<PropertyId, object> prop in props)
            {
                if (prop.Key.IsTag)
                {
                    uint tag = prop.Key.Tag;
                    sortedList[tag] = ((tag == 202702851) ? ((object)(uint)(int)prop.Value) : prop.Value);
                }
            }
            return sortedList;
        }
    }
}

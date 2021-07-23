using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models
{
    static class InternalProps
    {
        internal static SortedList<PropertyId, object> Skip(IDictionary<PropertyId, object> props)
        {
            SortedList<PropertyId, object> sortedList = new SortedList<PropertyId, object>();
            foreach (KeyValuePair<PropertyId, object> prop in props)
            {
                if (!prop.Key.IsTag || !IsInternal(prop.Key.Tag))
                {
                    sortedList[prop.Key] = prop.Value;
                }
            }
            return sortedList;
        }

        internal static bool IsInternal(uint tag)
        {
            uint num = MAPIProps.Id(tag);
            if (num >= 26112)
            {
                return num <= 26623;
            }
            return false;
        }
    }
}

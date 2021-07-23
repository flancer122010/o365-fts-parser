using MailFTSParsers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models
{
    public interface IAttachInfo
    {
        SortedList<PropertyId, object> Properties
        {
            get;
            set;
        }

        string Name
        {
            get;
            set;
        }

        string ContentId
        {
            get;
            set;
        }

        bool Hidden
        {
            get;
            set;
        }

        AttachMethod Method
        {
            get;
            set;
        }

        string LongFileName
        {
            get;
            set;
        }
    }
}

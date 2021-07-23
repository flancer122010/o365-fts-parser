using MailFTSParsers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models.Impl
{
    public class AttachInfo : IAttachInfo
    {
        public SortedList<PropertyId, object> Properties
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string ContentId
        {
            get;
            set;
        }

        public bool Hidden
        {
            get;
            set;
        }

        public AttachMethod Method
        {
            get;
            set;
        }

        public string LongFileName
        {
            get;
            set;
        }

        public byte[] Content
        {
            get;
            set;
        }

        public ItemInfo Embedded
        {
            get;
            set;
        }
    }
}

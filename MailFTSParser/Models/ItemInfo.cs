using MailFTSParsers.Models.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models
{
    public class ItemInfo
    {
        public ICollection<SortedList<uint, object>> Recipients
        {
            get;
            set;
        }

        public SortedList<PropertyId, object> Properties
        {
            get;
            set;
        }

        public Body Body
        {
            get;
            set;
        }

        public ICollection<AttachInfo> Attachments
        {
            get;
            set;
        }

        public Boolean HasAttachments
        {
            get;
            set;
        }

        public String DisplayName
        {
            get;
            set;
        }

        public DateTime CreatedTime
        {
            get;
            set;
        }

        public long Size
        {
            get;
            set;
        }

        public String ItemClass
        {
            get;
            set;
        }

        public String EmailAddress
        {
            get;
            set;
        }

        public String Subject
        {
            get;
            set;
        }

        public Int32 Flag
        {
            get;
            set;
        }

        //https://msdn.microsoft.com/en-us/library/ee160304(v=exchg.80).aspx
        public Boolean IsUnread
        {
            get
            {
                return ((Flag >> 0) & 1) == 0 ? true : false; 
            }
        }

        //mfUnsent  - 1000
        public Boolean IsDraft
        {
            get
            {
                return ((Flag >> 3) & 1) == 0 ? true : false;
            }
        }

        public DateTime EndTime
        {
            get;
            set;
        }

        public DateTime StartTime
        {
            get;
            set;
        }

        public DateTime LastModifiedTime
        {
            get;
            set;
        }

        public DateTime SubmittedTime
        {
            get;
            set;
        }
        
        // 0 - LowImportance, 1 - Normal,  2 - HighImportance
        public Int32 Importance
        {
            get; set;
        }

        // 0 - Normal, 1 - Personal,  2 - Private, 3 - Confidential
        public Int32 Sensitivity
        {
            get; set;
        }

        // 0 - Urgent, 1 - Normal,  2 - Not Urgent
        public Int32 Priority
        {
            get; set;
        }


    }
}

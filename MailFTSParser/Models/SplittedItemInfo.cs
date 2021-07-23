using MailFTSParsers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models
{
    public class SplittedItemInfo
    {
        public byte[] ItemProps
        {
            get;
            set;
        }

        public byte[] Body
        {
            get;
            set;
        }

        public BodyType BodyType
        {
            get;
            set;
        }

        public byte[] Recipients
        {
            get;
            set;
        }

        public SplittedAttachInfo[] Attaches
        {
            get;
            set;
        }
    }

}

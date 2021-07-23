using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models
{
    public class SplittedAttachInfo
    {
        public byte[] SerializedProps
        {
            get;
            set;
        }

        public byte[] Content
        {
            get;
            set;
        }
    }
}

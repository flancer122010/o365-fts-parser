using MailFTSParsers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models
{
    public class Body
    {
        public BodyType Type
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

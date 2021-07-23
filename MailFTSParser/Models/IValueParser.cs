using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models
{
    public interface IValueParser
    {
        int DataSize
        {
            get;
        }

        uint MAPIType
        {
            get;
        }

        object GetValue(byte[] value);
    }
}

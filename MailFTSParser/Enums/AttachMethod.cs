using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Enums
{
    public enum AttachMethod
    {
        None,
        Value,
        Reference,
        ReferenceResolve,
        ReferenceOnly,
        Embedded,
        Storage,
        WebReference
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Enums
{
    enum Opcodes
    {
        None,
        Config,
        TransferBuffer,
        IsInterfaceOk,
        TellPartnerVersion,
        StartMdbEventsImport = 11,
        FinishMdbEventsImport,
        AddMdbEvents,
        SetWatermarks,
        SetReceiveFolder,
        SetPerUser,
        SetProps
    }
}

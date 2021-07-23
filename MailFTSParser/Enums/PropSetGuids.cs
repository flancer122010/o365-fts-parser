using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Enums
{
    public static class PropSetGuids
    {
        public static readonly Guid Appointment = new Guid("{00062002-0000-0000-C000-000000000046}");

        public static readonly Guid Address = new Guid("{00062004-0000-0000-C000-000000000046}");

        public static readonly Guid Common = new Guid("{00062008-0000-0000-C000-000000000046}");

        public static readonly Guid Log = new Guid("{0006200A-0000-0000-C000-000000000046}");

        public static readonly Guid Task = new Guid("{00062003-0000-0000-C000-000000000046}");

    }
}

using MailFTSParsers.Models;
using System;

namespace MailFTSParsers.Parsers
{
	public class BooleanParser : IValueParser
	{
		public int DataSize {
            get {
                return 2;
            }
        }

		public uint MAPIType
        {
            get { return 11u; }
        }

		public object GetValue(byte[] value)
		{
			return BitConverter.ToUInt16(value, 0) != 0;
		}
	}
}

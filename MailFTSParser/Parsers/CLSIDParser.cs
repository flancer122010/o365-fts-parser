using MailFTSParsers.Models;
using System;

namespace MailFTSParsers.Parsers
{
	public class CLSIDParser : IValueParser
	{
		public int DataSize
        {
            get { return 16; }
        }

		public uint MAPIType
        {
            get { return 72u; }
        }

		public object GetValue(byte[] value)
		{
			return new Guid(value);
		}
	}
}

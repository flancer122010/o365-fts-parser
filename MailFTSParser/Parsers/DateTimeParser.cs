using MailFTSParsers.Models;
using System;


namespace MailFTSParsers.Parsers
{
	public class DateTimeParser : IValueParser
	{
		public int DataSize
        {
            get {
                return 8;
            }
        }

		public uint MAPIType {
            get {
                return 64u;
            }
        }

		public object GetValue(byte[] value)
		{
			return new FileTime(BitConverter.ToInt64(value, 0));
		}
	}
}

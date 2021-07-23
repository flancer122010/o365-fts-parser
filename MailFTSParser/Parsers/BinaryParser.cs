using MailFTSParsers.Models;

namespace MailFTSParsers.Parsers
{
	public class BinaryParser : IValueParser
	{
		public int DataSize
        {
            get { return 0; }
        }

		public uint MAPIType
        {
            get { return 258u; }
        }

		public object GetValue(byte[] value)
		{
			return value;
		}
	}
}

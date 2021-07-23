using MailFTSParsers.Models;
using System.Text;

namespace MailFTSParsers.Parsers
{
	public class StringValueParser : IValueParser
	{
		private readonly Encoding encoding;
		public int DataSize
        {
            get { return 0; }
        }
		public uint MAPIType
        {
            get { return 31u; }
        }
		public StringValueParser(Encoding encoding)
		{
			this.encoding = encoding;
		}
		public object GetValue(byte[] value)
		{
			string @string = encoding.GetString(value);
			return @string.Substring(0, @string.Length - 1);
		}
	}
}

using MailFTSParsers.Models;

namespace MailFTSParsers.Parsers
{
	public interface IPropertyParser
	{
		bool Parse(BinReader reader);
	}
}

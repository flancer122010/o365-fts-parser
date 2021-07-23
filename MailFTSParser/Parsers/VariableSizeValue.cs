using MailFTSParsers.Models;

namespace MailFTSParsers.Parsers
{
    public class VariableSizeValue
    {
        private int tmp;

        private byte[] value;

        public byte[] Value
        {
            get { return value; }
        }

        public bool Parse(BinReader reader)
		{
			if (value == null)
			{
				if (reader.EndOfBuffer)
				{
					return false;
				}
				int num = reader.ReadInt32();
				value = new byte[num];
			}
			int num2 = value.Length - tmp;
			int num3 = reader.ReadBytes(value, tmp, num2);
			tmp += num3;
			return num3 == num2;
		}
	}
}

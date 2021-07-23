using MailFTSParsers.Models;
using System;

namespace MailFTSParsers.Parsers
{
	public class FixedValueParser<T> : IValueParser
	{
		private readonly Func<byte[], int, T> converter;

        private readonly int dataSize;
        public int DataSize {
            get {
                return dataSize;
            }
        }

        private readonly uint mapiType;
        public uint MAPIType
        {
            get { return mapiType; }
        }

		public FixedValueParser(int dataSize, uint mapiType, Func<byte[], int, T> converter)
		{
			this.dataSize = dataSize;
            this.mapiType = mapiType;
            this.converter = converter;
		}

		public object GetValue(byte[] value)
		{
			return this.converter(value, 0);
		}
	}
}

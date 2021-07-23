using MailFTSParsers.Models;
using System;
using System.Collections.Generic;


namespace MailFTSParsers.Parsers
{
	public class VariableSizeProperty : IPropertyParser
	{
        private int start;
        private List<byte> tmp = new List<byte>();
        private readonly PropertyId propertyId;
		private VariableSizeValue variableSizeValue = new VariableSizeValue();
        private readonly IValueParser valueParser;
        private readonly Action<byte[], PropertyId, byte[], IValueParser> builder;
        public VariableSizeProperty(int start, PropertyId propertyId, IValueParser valueParser, Action<byte[], PropertyId, byte[], IValueParser> builder)
		{
			this.start = start;
            this.propertyId = propertyId;
			this.valueParser = valueParser;
			this.builder = builder;
		}
		public bool Parse(BinReader reader)
		{
			if (variableSizeValue.Parse(reader))
			{
				byte[] arg = reader.FinishTail(tmp, start);
				builder(arg, propertyId, variableSizeValue.Value, valueParser);
				return true;
			}
			reader.AddToTail(tmp, start);
			start = 0;
			return false;
		}
	}
}

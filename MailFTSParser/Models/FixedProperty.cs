using MailFTSParsers.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models
{
    public class FixedProperty : IPropertyParser
    {
        private readonly PropertyId _prop;

        private readonly IValueParser _parser;

        private readonly Action<byte[], PropertyId, byte[], IValueParser> _builder;

        private List<byte> _tail = new List<byte>();

        private int _start;

        public FixedProperty(int start, PropertyId prop, IValueParser parser, Action<byte[], PropertyId, byte[], IValueParser> builder)
        {
            _start = start;
            _prop = prop;
            _parser = parser;
            _builder = builder;
        }

        public bool Parse(BinReader reader)
        {
            if (reader.EndOfBuffer)
            {
                reader.AddToTail(_tail, _start);
                _start = 0;
                return false;
            }
            byte[] arg = reader.ReadBytes(_parser.DataSize);
            byte[] arg2 = reader.FinishTail(_tail, _start);
            _builder(arg2, _prop, arg, _parser);
            return true;
        }
    }
}

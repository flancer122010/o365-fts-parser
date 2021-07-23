using MailFTSParsers.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models
{
    class MVProperty : IPropertyParser
    {
        private readonly PropertyId _prop;

        private readonly IValueParser _parser;

        private readonly Action<byte[], PropertyId, byte[][], IValueParser> _builder;

        private int _count;

        private object[] _data;

        private byte[][] _data2;

        private VariableSizeValue _varSize;

        private List<byte> _tail = new List<byte>();

        private int _start;

        public MVProperty(int start, PropertyId prop, IValueParser parser, Action<byte[], PropertyId, byte[][], IValueParser> builder)
        {
            _start = start;
            _prop = prop;
            _parser = parser;
            _builder = builder;
        }

        private bool MakeTail(BinReader reader)
        {
            reader.AddToTail(_tail, _start);
            _start = 0;
            return false;
        }

        public bool Parse(BinReader reader)
        {
            if (_data == null)
            {
                if (reader.EndOfBuffer)
                {
                    return MakeTail(reader);
                }
                int num = reader.ReadInt32();
                if (num <= 0)
                {
                    throw new Exception("ErrInvalidMVCount"); //, num, reader.Offset), null);
                }
                _data = new object[num];
                _data2 = new byte[num][];
            }
            if (_parser.DataSize > 0)
            {
                while (_count < _data.Length && !reader.EndOfBuffer)
                {
                    byte[] array = reader.ReadBytes(_parser.DataSize);
                    _data[_count] = _parser.GetValue(array);
                    _data2[_count++] = array;
                }
            }
            else
            {
                if (_varSize != null)
                {
                    if (!_varSize.Parse(reader))
                    {
                        return MakeTail(reader);
                    }
                    _data[_count] = _parser.GetValue(_varSize.Value);
                    _data2[_count++] = _varSize.Value;
                    _varSize = null;
                }
                while (_count < _data.Length)
                {
                    VariableSizeValue varSizeValue = new VariableSizeValue();
                    if (varSizeValue.Parse(reader))
                    {
                        _data[_count] = _parser.GetValue(varSizeValue.Value);
                        _data2[_count++] = varSizeValue.Value;
                        continue;
                    }
                    _varSize = varSizeValue;
                    return MakeTail(reader);
                }
            }
            if (_count == _data.Length)
            {
                byte[] arg = reader.FinishTail(_tail, _start);
                _builder(arg, _prop, _data2, _parser);
                return true;
            }
            return MakeTail(reader);
        }
    }
}

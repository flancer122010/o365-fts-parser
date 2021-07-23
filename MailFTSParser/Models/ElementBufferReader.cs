using MailFTSParsers.Parsers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models
{

    public struct FileTime
    {
        public long Value;

        public FileTime(long v)
        {
            Value = v;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is FileTime))
            {
                return false;
            }
            return Value == ((FileTime)obj).Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }

        public static bool operator ==(FileTime x, FileTime y)
        {
            return x.Value == y.Value;
        }

        public static bool operator !=(FileTime x, FileTime y)
        {
            return !(x == y);
        }

        public static bool operator >(FileTime x, FileTime y)
        {
            return x.Value > y.Value;
        }

        public static bool operator >=(FileTime x, FileTime y)
        {
            return x.Value >= y.Value;
        }

        public static bool operator <(FileTime x, FileTime y)
        {
            return x.Value < y.Value;
        }

        public static bool operator <=(FileTime x, FileTime y)
        {
            return x.Value <= y.Value;
        }

        public static int Compare(FileTime x, FileTime y)
        {
            if (x.Value == y.Value)
            {
                return 0;
            }
            if (x.Value <= y.Value)
            {
                return -1;
            }
            return 1;
        }

        public static implicit operator FileTime(DateTime dateTime)
        {
            return new FileTime(dateTime.ToFileTimeUtc());
        }

        public static implicit operator DateTime(FileTime fileTime)
        {
            return DateTime.FromFileTimeUtc(fileTime.Value);
        }
    }

    public struct Currency
    {
        public long Value;

        public Currency(long v)
        {
            Value = v;
        }

        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }
    }
    public struct AppTime
    {
        public double Value;

        public AppTime(double v)
        {
            Value = v;
        }

        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }
    }

    public class ElementBufferReader
    {
        private readonly IElementBuilder builder;

        private readonly BinReader reader;

        private static readonly ISet<uint> MarkerSet;

        private static readonly IDictionary<ushort, IValueParser> ValueParsers;

        private static readonly IValueParser UnicodeValueParser;

        static ElementBufferReader()
        {
            MarkerSet = new HashSet<uint>();
            ValueParsers = new Dictionary<ushort, IValueParser>();
            UnicodeValueParser = new StringValueParser(Encoding.Unicode);
            MarkerSet.Add(1073741827u);
            MarkerSet.Add(1074659331u);
            MarkerSet.Add(1073807363u);
            MarkerSet.Add(1073872899u);
            MarkerSet.Add(1073938435u);
            MarkerSet.Add(1074003971u);
            ValueParsers[11] = new BooleanParser();
            ValueParsers[2] = new FixedValueParser<short>(2, 2u, BitConverter.ToInt16);
            ValueParsers[3] = new FixedValueParser<int>(4, 3u, BitConverter.ToInt32);
            ValueParsers[20] = new FixedValueParser<long>(8, 20u, BitConverter.ToInt64);
            ValueParsers[6] = new FixedValueParser<Currency>(8, 6u, ToCurrency);
            ValueParsers[7] = new FixedValueParser<AppTime>(8, 7u, ToAppTime);
            ValueParsers[4] = new FixedValueParser<float>(4, 4u, BitConverter.ToSingle);
            ValueParsers[5] = new FixedValueParser<double>(8, 5u, BitConverter.ToDouble);
            ValueParsers[64] = new DateTimeParser();
            ValueParsers[258] = new BinaryParser();
            ValueParsers[72] = new CLSIDParser();
            ValueParsers[251] = new BinaryParser();
            ValueParsers[13] = new BinaryParser();
        }

        private static AppTime ToAppTime(byte[] data, int offset)
        {
            return new AppTime(BitConverter.ToDouble(data, offset));
        }

        private static Currency ToCurrency(byte[] data, int offset)
        {
            return new Currency(BitConverter.ToInt64(data, offset));
        }

        internal ElementBufferReader(IElementBuilder builder, BinReader reader)
        {
            this.builder = builder;
            this.reader = reader;
        }

        internal IPropertyParser Read()
        {
            while (!this.reader.EndOfBuffer)
            {
                IPropertyParser propParser = ReadProperty();
                if (propParser != null)
                {
                    return propParser;
                }
            }
            return null;
        }

        private IPropertyParser ReadProperty()
        {
            int offset = this.reader.Offset;
            ushort num = this.reader.ReadUInt16();
            ushort num2 = this.reader.ReadUInt16();
            if (CheckMarker(num2, num))
            {
                return null;
            }
            bool flag = (num & 0x1000) != 0;
            IValueParser valueParser = GetValueParser((ushort)(num & 0xEFFF));
            PropertyId PropertyId = (num2 >= 32768) ? ReadNamedPropertyId() : new PropertyId(MAPIProps.Tag(num2, (uint)((int)valueParser.MAPIType | (flag ? 4096 : 0))));
            IPropertyParser propParser;
            if (flag)
            {
                int start = offset;
                PropertyId prop = PropertyId;
                IValueParser parser = valueParser;
                IElementBuilder builder = this.builder;
                propParser = new MVProperty(start, prop, parser, builder.PropMV);
            }
            else if (valueParser.DataSize > 0)
            {
                int start2 = offset;
                PropertyId prop2 = PropertyId;
                IValueParser parser2 = valueParser;
                IElementBuilder builder2 = this.builder;
                propParser = new FixedProperty(start2, prop2, parser2, builder2.Prop);
            }
            else
            {
                int start3 = offset;
                PropertyId prop3 = PropertyId;
                IValueParser parser3 = valueParser;
                IElementBuilder builder3 = this.builder;
                propParser = new VariableSizeProperty(start3, prop3, parser3, builder3.Prop);
            }
            if (propParser.Parse(this.reader))
            {
                return null;
            }
            return propParser;
        }

        private PropertyId ReadNamedPropertyId()
        {
            Guid n = this.reader.ReadGuid();
            byte b = this.reader.ReadByte();
            if (b != 0 && b != 1)
            {
                //throw new ParseError(string.Format(Resources.ErrInvalidNamedProperty, b, _reader.Offset - 1), null);
            }
            if (b == 0)
            {
                int i = this.reader.ReadInt32();
                return new PropertyId(n, i);
            }
            string s = this.reader.ReadString();
            return new PropertyId(n, s);
        }

        private bool CheckMarker(ushort tagId, ushort type)
        {
            if (type != 3)
            {
                return false;
            }
            uint num = MAPIProps.Tag(tagId, 3u);
            if (MarkerSet.Contains(num))
            {
                this.builder.Marker(num);
                return true;
            }
            return false;
        }

        private static IValueParser GetValueParser(ushort type)
        {
            if ((type & 0x8000) != 0)
            {
                int num = type & 0xFFF;
                if (num == 1200)
                {
                    return UnicodeValueParser;
                }
                return new StringValueParser(Encoding.GetEncoding(num));
            }
            if (!ValueParsers.TryGetValue(type, out IValueParser result))
            {
                throw new Exception("Unknown property type");
            }
            return result;
        }
    }


    public static class FileTimeExtension
    {
        public static DateTime ToDateTime(this FileTime fileTime)
        {
            return DateTime.FromFileTimeUtc(fileTime.Value);
        }
    }
}

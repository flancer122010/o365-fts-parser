using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models
{
    public class BinReader
    {
        private readonly byte[] buffer;

        private int offset;

        internal int Offset
        {
            get
            {
                return offset;
            }
        }

        internal bool EndOfBuffer
        {
            get
            {
                return offset >= buffer.Length;
            }
        }
        internal BinReader(byte[] buffer, int offset = 0)
        {
            this.buffer = buffer;
            this.offset = offset;
        }

        internal void Ensure(int size)
        {
            int num = this.buffer.Length - this.offset;
            if (num >= size)
            {
                return;
            }
            throw new Exception("Not enough buffer space available");
        }

        internal byte[] ReadBytes(int dataSize)
        {
            Ensure(dataSize);
            byte[] array = new byte[dataSize];
            Array.Copy(this.buffer, this.offset, array, 0, dataSize);
            this.offset += dataSize;
            return array;
        }

        internal ushort ReadUInt16()
        {
            Ensure(2);
            ushort result = BitConverter.ToUInt16(this.buffer, this.offset);
            this.offset += 2;
            return result;
        }

        internal int ReadInt32()
        {
            Ensure(4);
            int result = BitConverter.ToInt32(this.buffer, this.offset);
            this.offset += 4;
            return result;
        }

        internal Guid ReadGuid()
        {
            Ensure(16);
            byte[] array = new byte[16];
            Array.Copy(this.buffer, this.offset, array, 0, 16);
            this.offset += 16;
            return new Guid(array);
        }

        internal string ReadString()
        {
            int offset = this.offset;
            ushort num = ushort.MaxValue;
            while (!EndOfBuffer)
            {
                num = ReadUInt16();
                if (num == 0)
                {
                    break;
                }
            }
            if (num != 0)
            {
                throw new Exception("Invalid Encoded String");
            }
            return Encoding.Unicode.GetString(this.buffer, offset, this.offset - offset - 2);
        }

        internal byte ReadByte()
        {
            Ensure(1);
            return this.buffer[this.offset++];
        }

        internal int ReadBytes(byte[] value, int offset, int size)
        {
            int num = this.buffer.Length - this.offset;
            int num2 = (size > num) ? num : size;
            Array.Copy(this.buffer, this.offset, value, offset, num2);
            this.offset += num2;
            return num2;
        }

        public byte[] GetDataFrom(int offset)
        {
            int num = this.offset - offset;
            if (num == 0)
            {
                return new byte[0];
            }
            return this.buffer.SubArray(offset, num);
        }
    }

    public static class BinReaderExtension
    {
        internal static void AddToTail(this BinReader reader, List<byte> tail, int offset)
        {
            tail.AddRange(reader.GetDataFrom(offset));
        }

        internal static byte[] FinishTail(this BinReader reader, List<byte> tail, int offset)
        {
            reader.AddToTail(tail, offset);
            return tail.ToArray();
        }
    }


    public static class ByteArrayExtension
    {
        public static string ToHexString(this byte[] array, bool addPrefix = true)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (addPrefix)
            {
                stringBuilder.Append("0x");
            }
            for (int i = 0; i < array.Length; i++)
            {
                byte b = array[i];
                stringBuilder.Append(b.ToString("X2"));
            }
            return stringBuilder.ToString();
        }

        public static byte[] SubArray(this byte[] data, int index, int length)
        {
            if (data.Length < index + length)
            {
                length = data.Length - index;
            }
            byte[] array = new byte[length];
            Array.Copy(data, index, array, 0, length);
            return array;
        }

        public static int Find(this byte[] source, byte[] pattern, int startIndex = 0)
        {
            for (int i = startIndex; i < source.Length; i++)
            {
                if (source[i] == pattern[0] && source.SubArray(i, pattern.Length).SequenceEqual(pattern))
                {
                    return i;
                }
            }
            return -1;
        }

        public static int ToInt32(this byte[] data)
        {
            if (data.Length <= 4 && data.Length != 0)
            {
                byte[] array = new byte[4];
                Array.Copy(data, array, data.Length);
                return BitConverter.ToInt32(array, 0);
            }
            return 0;
        }
    }

}

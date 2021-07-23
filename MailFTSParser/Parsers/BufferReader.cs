using MailFTSParsers.Enums;
using System;
using System.IO;


namespace MailFTSParsers.Parsers
{
	internal class BufferReader : IDisposable
	{
		private BinaryReader binaryReader;

		private static readonly Guid InterfaceId = Guid.Parse("{00020307-0000-0000-C000-000000000046}");

		public BufferReader(Stream stream)
		{
            binaryReader = new BinaryReader(stream);
		}

		public void Dispose()
		{
			if (binaryReader != null)
			{
				BinaryReader reader = binaryReader;
                binaryReader = null;
				reader.Dispose();
			}
		}

		public void Open()
		{
			ReadOpcode(Opcodes.Config, 8);
			uint num = binaryReader.ReadUInt32();
			int num2 = binaryReader.ReadInt32();
			if (num == 0 && num2 == 1)
			{
				ReadOpcode(Opcodes.IsInterfaceOk, 24);
				num2 = binaryReader.ReadInt32();
				Guid guid = new Guid(binaryReader.ReadBytes(16));
				num = binaryReader.ReadUInt32();
				if (num2 == 1 && guid == InterfaceId && num == 2147492864u)
				{
					ReadOpcode(Opcodes.TellPartnerVersion, 6);
					ushort num3 = binaryReader.ReadUInt16();
					ushort num4 = binaryReader.ReadUInt16();
					ushort num5 = binaryReader.ReadUInt16();
					if (num3 >= 3584)
					{
						return;
					}
                    throw new Exception("UnsupportedSerializedVersion");
				}
                throw new Exception("UnsupportedSerializeInterface");
            }
            throw new Exception("UnsupportedSerializedFlagsAndMethod");
        }

		private void ReadOpcode(Opcodes expected, int length)
		{
			ReadOpcode(expected);
			if (binaryReader.ReadInt32() == length)
			{
				return;
			}
            throw new Exception("InvalidDataLength");

        }

		private void ReadOpcode(Opcodes expected)
		{
			Opcodes opcodes = (Opcodes)binaryReader.ReadInt32();
			if (opcodes == expected)
			{
				return;
			}
            throw new Exception("UnexpectedOpcode");

        }

		public byte[] GetNextBuffer()
		{
			long num = binaryReader.BaseStream.Length - binaryReader.BaseStream.Position;
			if (num == 0L)
			{
				return null;
			}
			if (num <= 8)
			{
                throw new Exception("InvalidDataStream");

            }
			ReadOpcode(Opcodes.TransferBuffer);
			int num2 = binaryReader.ReadInt32();
			if (num - 8 < num2)
			{
                throw new Exception("InvalidDataStream");

            }
			return binaryReader.ReadBytes(num2);
		}
	}
}

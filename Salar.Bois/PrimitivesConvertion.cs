﻿using System;
using System.IO;

/* 
 * Salar BOIS (Binary Object Indexed Serialization)
 * by Salar Khalilzadeh
 * 
 * https://bois.codeplex.com/
 * Mozilla Public License v2
 */
namespace Salar.Bois
{
	internal static class PrimitivesConvertion
	{
		/// <summary>
		/// 0011 1111
		/// </summary>
		private const byte NullableMaxNumInByte = 63;

		/// <summary>
		/// 0111 1111
		/// </summary>
		private const byte NullableFlagNullMask = 127;

		/// <summary>
		/// 1000 0000
		/// </summary>
		private const byte NullableFlagNullNum = 128;

		/// <summary>
		/// 1011 1111
		/// </summary>
		private const byte NullableFlagInsideMask = 191;

		/// <summary>
		/// 0100 0000
		/// </summary>
		private const byte NullableFlagInsideNum = 64;

		/// <summary>
		/// 0111 1111
		/// </summary>
		private const byte ActualMaxNumInByte = 127;

		/// <summary>
		/// 0111 1111
		/// </summary>
		private const byte ActualFlagInsideMask = 127;

		/// <summary>
		/// 1000 0000
		/// </summary>
		private const byte ActualFlagInsideNum = 128;

		/// <summary>
		/// 
		/// </summary>
		internal static short ReadVarInt16(BinaryReader reader)
		{
			var input = reader.ReadByte();
			var isItInside = (input & ActualFlagInsideNum) == ActualFlagInsideNum;

			var insideNum = (short)(input & ActualFlagInsideMask);
			if (isItInside)
			{
				return insideNum;
			}
			else
			{
				return ReadInt16(reader, insideNum);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		internal static short? ReadVarInt16Nullable(BinaryReader reader)
		{
			var input = reader.ReadByte();
			if (input == NullableFlagNullNum)
				return null;

			var isnull = (input & NullableFlagNullNum) == NullableFlagNullNum;
			if (isnull)
				return null;

			var insideNum = (byte)(input & NullableFlagInsideMask);
			insideNum = (byte)(insideNum & NullableFlagNullMask);

			var isItInside = (input & NullableFlagInsideNum) == NullableFlagInsideNum;
			if (isItInside)
			{
				return insideNum;
			}
			else
			{
				return ReadInt16(reader, insideNum);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		internal static decimal ReadVarDecimal(BinaryReader reader)
		{
			var input = reader.ReadByte();
			var isItInside = (input & ActualFlagInsideNum) == ActualFlagInsideNum;

			var insideNum = (byte)(input & ActualFlagInsideMask);
			if (isItInside)
			{
				return ReadDecimal(insideNum);
			}
			else
			{
				return ReadDecimal(reader, insideNum);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		internal static decimal? ReadVarDecimalNullable(BinaryReader reader)
		{
			var input = reader.ReadByte();
			if (input == NullableFlagNullNum)
				return null;

			var isnull = (input & NullableFlagNullNum) == NullableFlagNullNum;
			if (isnull)
				return null;


			var insideNum = (byte)(input & NullableFlagInsideMask);
			insideNum = (byte)(insideNum & NullableFlagNullMask);

			var isItInside = (input & NullableFlagInsideNum) == NullableFlagInsideNum;
			if (isItInside)
			{
				return ReadDecimal(insideNum);
			}
			else
			{
				return ReadDecimal(reader, insideNum);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		internal static int ReadVarInt32(BinaryReader reader)
		{
			var input = reader.ReadByte();
			var isItInside = (input & ActualFlagInsideNum) == ActualFlagInsideNum;

			var insideNum = (input & ActualFlagInsideMask);
			if (isItInside)
			{
				return insideNum;
			}
			else
			{
				return ReadInt32(reader, insideNum);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		internal static int? ReadVarInt32Nullable(BinaryReader reader)
		{
			var input = reader.ReadByte();
			if (input == NullableFlagNullNum)
				return null;

			var isnull = (input & NullableFlagNullNum) == NullableFlagNullNum;
			if (isnull)
				return null;


			var insideNum = (byte)(input & NullableFlagInsideMask);
			insideNum = (byte)(insideNum & NullableFlagNullMask);

			var isItInside = (input & NullableFlagInsideNum) == NullableFlagInsideNum;
			if (isItInside)
			{
				return insideNum;
			}
			else
			{
				return ReadInt32(reader, insideNum);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		internal static uint ReadVarUInt32(BinaryReader reader)
		{
			var input = reader.ReadByte();
			var isItInside = (input & ActualFlagInsideNum) == ActualFlagInsideNum;

			var insideNum = (byte)(input & ActualFlagInsideMask);
			if (isItInside)
			{
				return insideNum;
			}
			else
			{
				return ReadUInt32(reader, insideNum);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		internal static uint? ReadVarUInt32Nullable(BinaryReader reader)
		{
			var input = reader.ReadByte();
			if (input == NullableFlagNullNum)
				return null;

			var isnull = (input & NullableFlagNullNum) == NullableFlagNullNum;
			if (isnull)
				return null;


			var insideNum = (byte)(input & NullableFlagInsideMask);
			insideNum = (byte)(insideNum & NullableFlagNullMask);

			var isItInside = (input & NullableFlagInsideNum) == NullableFlagInsideNum;
			if (isItInside)
			{
				return insideNum;
			}
			else
			{
				return ReadUInt32(reader, insideNum);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		internal static long ReadVarInt64(BinaryReader reader)
		{
			var input = reader.ReadByte();
			var isItInside = (input & ActualFlagInsideNum) == ActualFlagInsideNum;

			var insideNum = (input & ActualFlagInsideMask);
			if (isItInside)
			{
				return insideNum;
			}
			else
			{
				return ReadInt64(reader, insideNum);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		internal static long? ReadVarInt64Nullable(BinaryReader reader)
		{
			var input = reader.ReadByte();
			if (input == 0)
				return null;

			var isnull = (input & NullableFlagNullNum) == NullableFlagNullNum;
			if (isnull)
				return null;


			var insideNum = (byte)(input & NullableFlagInsideMask);
			insideNum = (byte)(insideNum & NullableFlagNullMask);

			var isItInside = (input & NullableFlagInsideNum) == NullableFlagInsideNum;
			if (isItInside)
			{
				return insideNum;
			}
			else
			{
				return ReadInt64(reader, insideNum);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		internal static ulong ReadVarUInt64(BinaryReader reader)
		{
			var input = reader.ReadByte();
			var isItInside = (input & ActualFlagInsideNum) == ActualFlagInsideNum;

			var insideNum = (byte)(input & ActualFlagInsideMask);
			if (isItInside)
			{
				return insideNum;
			}
			else
			{
				return ReadUInt64(reader, insideNum);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		internal static ulong? ReadVarUInt64Nullable(BinaryReader reader)
		{
			var input = reader.ReadByte();
			if (input == 0)
				return null;

			var isnull = (input & NullableFlagNullNum) == NullableFlagNullNum;
			if (isnull)
				return null;


			var insideNum = (byte)(input & NullableFlagInsideMask);
			insideNum = (byte)(insideNum & NullableFlagNullMask);

			var isItInside = (input & NullableFlagInsideNum) == NullableFlagInsideNum;
			if (isItInside)
			{
				return insideNum;
			}
			else
			{
				return ReadUInt64(reader, insideNum);
			}
		}

		internal static double? ReadVarDoubleNullable(BinaryReader reader)
		{
			var input = reader.ReadByte();
			if (input == 0)
				return null;

			var isnull = (input & NullableFlagNullNum) == NullableFlagNullNum;
			if (isnull)
				return null;


			var insideNum = (byte)(input & NullableFlagInsideMask);
			insideNum = (byte)(insideNum & NullableFlagNullMask);

			var isItInside = (input & NullableFlagInsideNum) == NullableFlagInsideNum;
			if (isItInside)
			{
				return ReadDouble(insideNum);
			}
			else
			{
				return ReadDouble(reader, insideNum);
			}
		}

		internal static double ReadVarDouble(BinaryReader reader)
		{
			var input = reader.ReadByte();
			var isItInside = (input & ActualFlagInsideNum) == ActualFlagInsideNum;

			var insideNum = (byte)(input & ActualFlagInsideMask);
			if (isItInside)
			{
				return ReadDouble(insideNum);
			}
			else
			{
				return ReadDouble(reader, insideNum);
			}
		}

		internal static float? ReadVarSingleNullable(BinaryReader reader)
		{
			var input = reader.ReadByte();
			if (input == 0)
				return null;

			var isnull = (input & NullableFlagNullNum) == NullableFlagNullNum;
			if (isnull)
				return null;


			var insideNum = (byte)(input & NullableFlagInsideMask);
			insideNum = (byte)(insideNum & NullableFlagNullMask);

			var isItInside = (input & NullableFlagInsideNum) == NullableFlagInsideNum;
			if (isItInside)
			{
				return ReadFloat(insideNum);
			}
			else
			{
				return ReadFloat(reader, insideNum);
			}
		}

		internal static float ReadVarSingle(BinaryReader reader)
		{
			var input = reader.ReadByte();
			var isItInside = (input & ActualFlagInsideNum) == ActualFlagInsideNum;

			var insideNum = (byte)(input & ActualFlagInsideMask);
			if (isItInside)
			{
				return ReadFloat(insideNum);
			}
			else
			{
				return ReadFloat(reader, insideNum);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		internal static void WriteVarInt(BinaryWriter writer, short num)
		{
			// store more space
			if (num > ActualMaxNumInByte || num < 0)
			{
				// No Flag is required
				// length of the integer bytes
				WriteInt(writer, num);
			}
			else
			{
				byte numByte = (byte)num;

				// set the flag of inside
				numByte = (byte)(numByte | ActualFlagInsideNum);
				writer.Write(numByte);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		internal static void WriteVarInt(BinaryWriter writer, short? num)
		{
			if (num == null)
			{
				writer.Write(NullableFlagNullNum);
				return;
			}
			// store more space
			if (num > NullableMaxNumInByte || num < 0)
			{
				// No Flag is required
				// length of the integer bytes
				WriteInt(writer, num.Value);
			}
			else
			{
				byte numByte = (byte)num;

				// set the flag of inside
				numByte = (byte)(numByte | NullableFlagInsideNum);
				writer.Write(numByte);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		internal static void WriteVarInt(BinaryWriter writer, int num)
		{
			// store more space
			if (num > ActualMaxNumInByte || num < 0)
			{
				// No Flag is required
				// length of the integer bytes
				WriteInt(writer, num);
			}
			else
			{
				byte numByte = (byte)num;

				// set the flag of inside
				numByte = (byte)(numByte | ActualFlagInsideNum);
				writer.Write(numByte);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		internal static void WriteVarInt(BinaryWriter writer, int? num)
		{
			if (num == null)
			{
				writer.Write(NullableFlagNullNum);
				return;
			}

			// store more space
			if (num > NullableMaxNumInByte || num < 0)
			{
				// No Flag is required
				// length of the integer bytes
				WriteInt(writer, num.Value);
			}
			else
			{
				byte numByte = (byte)num.Value;

				// set the flag of inside
				numByte = (byte)(numByte | NullableFlagInsideNum);
				writer.Write(numByte);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		internal static void WriteVarInt(BinaryWriter writer, uint num)
		{
			// store more space
			if (num > ActualMaxNumInByte)
			{
				// No Flag is required
				// length of the integer bytes
				WriteInt(writer, num);
			}
			else
			{
				byte numByte = (byte)num;

				// set the flag of inside
				numByte = (byte)(numByte | ActualFlagInsideNum);
				writer.Write(numByte);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		internal static void WriteVarInt(BinaryWriter writer, uint? num)
		{
			if (num == null)
			{
				writer.Write(NullableFlagNullNum);
				return;
			}

			// store more space
			if (num > NullableMaxNumInByte)
			{
				// No Flag is required
				// length of the integer bytes
				WriteInt(writer, num.Value);
			}
			else
			{
				byte numByte = (byte)num.Value;

				// set the flag of inside
				numByte = (byte)(numByte | NullableFlagInsideNum);
				writer.Write(numByte);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		internal static void WriteVarInt(BinaryWriter writer, long num)
		{
			// store more space
			if (num > ActualMaxNumInByte || num < 0)
			{
				// No Flag is required
				// length of the integer bytes
				WriteInt(writer, num);
			}
			else
			{
				byte numByte = (byte)num;

				// set the flag of inside
				numByte = (byte)(numByte | ActualFlagInsideNum);
				writer.Write(numByte);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		internal static void WriteVarInt(BinaryWriter writer, long? num)
		{
			if (num == null)
			{
				writer.Write(NullableFlagNullNum);
				return;
			}

			// store more space
			if (num > NullableMaxNumInByte || num < 0)
			{
				// No Flag is required
				// length of the integer bytes
				WriteInt(writer, num.Value);
			}
			else
			{
				byte numByte = (byte)num.Value;

				// set the flag of inside
				numByte = (byte)(numByte | NullableFlagInsideNum);
				writer.Write(numByte);
			}
		}
		internal static void WriteVarInt(BinaryWriter writer, ulong num)
		{
			// store more space
			if (num > ActualMaxNumInByte)
			{
				// No Flag is required
				// length of the integer bytes
				WriteInt(writer, num);
			}
			else
			{
				byte numByte = (byte)num;

				// set the flag of inside
				numByte = (byte)(numByte | ActualFlagInsideNum);
				writer.Write(numByte);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		internal static void WriteVarInt(BinaryWriter writer, ulong? num)
		{
			if (num == null)
			{
				writer.Write(NullableFlagNullNum);
				return;
			}

			// store more space
			if (num > NullableMaxNumInByte)
			{
				// No Flag is required
				// length of the integer bytes
				WriteInt(writer, num.Value);
			}
			else
			{
				byte numByte = (byte)num.Value;

				// set the flag of inside
				numByte = (byte)(numByte | NullableFlagInsideNum);
				writer.Write(numByte);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		internal static void WriteVarDecimal(BinaryWriter writer, float? num)
		{
			if (num == null)
			{
				writer.Write(NullableFlagNullNum);
				return;
			}
			byte length;
			var buff = ConvertToVarBinary(num.Value, out length);

			// if the value can be stored in one byte
			if (length == 1 && buff[0] <= NullableMaxNumInByte)
			{
				byte numByte = buff[0];
				// set the flag of inside
				numByte = (byte)(numByte | NullableFlagInsideNum);
				writer.Write(numByte);
			}
			else
			{
				// No Flag is required
				WriteDecimal(writer, buff, length);
			}
		}

		internal static void WriteVarDecimal(BinaryWriter writer, float num)
		{
			byte length;
			var buff = ConvertToVarBinary(num, out length);

			// store more space
			// if the value can be stored in one byte
			if (length == 1 && buff[0] <= ActualMaxNumInByte)
			{
				byte numByte = buff[0];

				// set the flag of inside
				numByte = (byte)(numByte | ActualFlagInsideNum);
				writer.Write(numByte);
			}
			else
			{
				// No Flag is required
				WriteDecimal(writer, buff, length);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		internal static void WriteVarDecimal(BinaryWriter writer, double? num)
		{
			if (num == null)
			{
				writer.Write(NullableFlagNullNum);
				return;
			}
			byte length;
			var buff = ConvertToVarBinary(num.Value, out length);

			// if the value can be stored in one byte
			if (length == 1 && buff[0] <= NullableMaxNumInByte)
			{
				byte numByte = buff[0];
				// set the flag of inside
				numByte = (byte)(numByte | NullableFlagInsideNum);
				writer.Write(numByte);
			}
			else
			{
				// No Flag is required
				WriteDecimal(writer, buff, length);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		internal static void WriteVarDecimal(BinaryWriter writer, double num)
		{
			byte length;
			var buff = ConvertToVarBinary(num, out length);

			// store more space
			// if the value can be stored in one byte
			if (length == 1 && buff[0] <= ActualMaxNumInByte)
			{
				byte numByte = buff[0];

				// set the flag of inside
				numByte = (byte)(numByte | ActualFlagInsideNum);
				writer.Write(numByte);
			}
			else
			{
				// No Flag is required
				WriteDecimal(writer, buff, length);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		internal static void WriteVarDecimal(BinaryWriter writer, decimal? num)
		{
			if (num == null)
			{
				writer.Write(NullableFlagNullNum);
				return;
			}
			byte length;
			var buff = ConvertToVarBinary(num.Value, out length);


			if (length == 0)
			{
				// no number is there, just the flag
				writer.Write(ActualFlagInsideNum);
			}
			else if (length == 1 && buff[0] <= NullableMaxNumInByte)
			{
				// if the value can be stored in one byte

				byte numByte = buff[0];

				// set the flag of inside
				numByte = (byte)(numByte | NullableFlagInsideNum);
				writer.Write(numByte);
			}
			else
			{
				// No Flag is required
				WriteDecimal(writer, buff, length);
			}
		}
		internal static void WriteVarDecimal(BinaryWriter writer, decimal num)
		{
			byte length;
			var buff = ConvertToVarBinary(num, out length);

			// store more space
			if (length == 0)
			{
				// no number is there, just the flag
				writer.Write(ActualFlagInsideNum);
			}
			else if (length == 1 && buff[0] <= ActualMaxNumInByte)
			{
				// if the value can be stored in one byte

				byte numByte = buff[0];

				// set the flag of inside
				numByte = (byte)(numByte | ActualFlagInsideNum);
				writer.Write(numByte);
			}
			else
			{
				// No Flag is required
				WriteDecimal(writer, buff, length);
			}
		}

		private static void WriteInt(BinaryWriter writer, long num)
		{
			byte numLen;
			var numBuff = ConvertToVarBinary(num, out numLen);
			writer.Write(numLen);
			writer.Write(numBuff, 0, numBuff.Length);
		}
		private static void WriteInt(BinaryWriter writer, ulong num)
		{
			byte numLen;
			var numBuff = ConvertToVarBinary(num, out numLen);
			writer.Write(numLen);
			writer.Write(numBuff, 0, numBuff.Length);
		}
		private static void WriteInt(BinaryWriter writer, int num)
		{
			byte numLen;
			var numBuff = ConvertToVarBinary(num, out numLen);
			writer.Write(numLen);
			writer.Write(numBuff, 0, numBuff.Length);
		}
		private static void WriteInt(BinaryWriter writer, uint num)
		{
			byte numLen;
			var numBuff = ConvertToVarBinary(num, out numLen);
			writer.Write(numLen);
			writer.Write(numBuff, 0, numBuff.Length);
		}
		private static void WriteInt(BinaryWriter writer, short num)
		{
			byte numLen;
			var numBuff = ConvertToVarBinary(num, out numLen);
			writer.Write(numLen);
			writer.Write(numBuff, 0, numBuff.Length);
		}

		private static void WriteDecimal(BinaryWriter writer, float num)
		{
			byte numLen;
			var numBuff = ConvertToVarBinary(num, out numLen);
			writer.Write(numLen);
			writer.Write(numBuff, 0, numBuff.Length);
		}

		private static void WriteDecimal(BinaryWriter writer, double num)
		{
			byte numLen;
			var numBuff = ConvertToVarBinary(num, out numLen);
			writer.Write(numLen);
			writer.Write(numBuff, 0, numBuff.Length);
		}

		private static void WriteDecimal(BinaryWriter writer, byte[] numBuff, byte numLen)
		{
			writer.Write(numLen);
			writer.Write(numBuff, 0, numBuff.Length);
		}

		private static long ReadInt64(BinaryReader reader, int length)
		{
			var intBuff = reader.ReadBytes(length);
			if (intBuff.Length == 8)
			{
				return ReadInt64(intBuff);
			}
			else
			{
				var intFinalBuff = new byte[8];

				Array.Copy(intBuff, intFinalBuff, intBuff.Length);
				return ReadInt64(intFinalBuff);
			}
		}
		private static ulong ReadUInt64(BinaryReader reader, int length)
		{
			var intBuff = reader.ReadBytes(length);
			if (intBuff.Length == 8)
			{
				return ReadUInt64(intBuff);
			}
			else
			{
				var intFinalBuff = new byte[8];

				Array.Copy(intBuff, intFinalBuff, intBuff.Length);
				return ReadUInt64(intFinalBuff);
			}
		}
		private static int ReadInt32(BinaryReader reader, int length)
		{
			var intBuff = reader.ReadBytes(length);
			if (intBuff.Length == 4)
			{
				return ReadInt32(intBuff);
			}
			else
			{
				var intFinalBuff = new byte[4];

				Array.Copy(intBuff, intFinalBuff, intBuff.Length);
				return ReadInt32(intFinalBuff);
			}
		}
		private static uint ReadUInt32(BinaryReader reader, int length)
		{
			var intBuff = reader.ReadBytes(length);
			if (intBuff.Length == 4)
			{
				return ReadUInt32(intBuff);
			}
			else
			{
				var intFinalBuff = new byte[4];

				Array.Copy(intBuff, intFinalBuff, intBuff.Length);
				return ReadUInt32(intFinalBuff);
			}
		}
		private static short ReadInt16(BinaryReader reader, short length)
		{
			var intBuff = reader.ReadBytes(length);
			if (intBuff.Length == 2)
			{
				return ReadInt16(intBuff);
			}
			else
			{
				var intFinalBuff = new byte[2];

				Array.Copy(intBuff, intFinalBuff, intBuff.Length);
				return ReadInt16(intFinalBuff);
			}
		}
		private static decimal ReadDecimal(BinaryReader reader, int length)
		{
			var intBuff = reader.ReadBytes(length);
			if (intBuff.Length == 16)
			{
				return ReadDecimal(intBuff);
			}
			else
			{
				var intFinalBuff = new byte[16];

				Array.Copy(intBuff, intFinalBuff, intBuff.Length);
				return ReadDecimal(intFinalBuff);
			}
		}

		private static long ReadInt64(byte[] intBytes)
		{
			uint num = (uint)(((intBytes[0] | (intBytes[1] << 8)) | (intBytes[2] << 16)) | (intBytes[3] << 24));
			uint num2 = (uint)(((intBytes[4] | (intBytes[5] << 8)) | (intBytes[6] << 16)) | (intBytes[7] << 24));
			return (long)((((ulong)num2) << 32) | ((ulong)num));
		}
		private static ulong ReadUInt64(byte[] intBytes)
		{
			uint num = (uint)(((intBytes[0] | (intBytes[1] << 8)) | (intBytes[2] << 16)) | (intBytes[3] << 24));
			uint num2 = (uint)(((intBytes[4] | (intBytes[5] << 8)) | (intBytes[6] << 16)) | (intBytes[7] << 24));
			return (ulong)((((ulong)num2) << 32) | ((ulong)num));
		}
		private static uint ReadUInt32(byte[] intBytes)
		{
			return (uint)(((intBytes[0] | (intBytes[1] << 8)) | (intBytes[2] << 16)) | (intBytes[3] << 24));
		}
		private static int ReadInt32(byte[] intBytes)
		{
			return ((intBytes[0] | (intBytes[1] << 8)) | (intBytes[2] << 16)) | (intBytes[3] << 24);
		}
		private static int ReadInt32(byte[] intBytes, int startIndex)
		{
			return ((intBytes[startIndex + 0] | (intBytes[startIndex + 1] << 8)) | (intBytes[startIndex + 2] << 16)) | (intBytes[startIndex + 3] << 24);
		}
		private static short ReadInt16(byte[] intBytes)
		{
			return (short)(intBytes[0] | (intBytes[1] << 8));
		}

		private static decimal ReadDecimal(byte[] decimalBytes)
		{
			var decimalBits = new int[4];
			decimalBits[0] = ReadInt32(decimalBytes, 4 * 0);
			decimalBits[1] = ReadInt32(decimalBytes, 4 * 1);
			decimalBits[2] = ReadInt32(decimalBytes, 4 * 2);
			decimalBits[3] = ReadInt32(decimalBytes, 4 * 3);

			return new decimal(decimalBits);
		}
		private static decimal ReadDecimal(byte decimalBytes)
		{
			if (decimalBytes == 0)
				return 0m;

			var decimalBits = new int[4];
			decimalBits[0] = decimalBytes;
			return new decimal(decimalBits);
		}

		private static double ReadDouble(byte doubleByte)
		{
			var bytes = new byte[8];
			bytes[7] = doubleByte;
			return BitConverter.ToDouble(bytes, 0);
		}

		private static float ReadFloat(byte floatByte)
		{
			var bytes = new byte[4];
			bytes[3] = floatByte;
			return BitConverter.ToSingle(bytes, 0);
		}

		private static float ReadFloat(BinaryReader reader, int length)
		{
			var intBuff = reader.ReadBytes(length);
			if (intBuff.Length == 4)
			{
				return BitConverter.ToSingle(intBuff, 0);
			}
			else
			{
				var intFinalBuff = new byte[4];

				Array.Copy(intBuff, 0, intFinalBuff, 4 - intBuff.Length, intBuff.Length);
				return BitConverter.ToSingle(intFinalBuff, 0);
			}
		}

		private static double ReadDouble(BinaryReader reader, int length)
		{
			var intBuff = reader.ReadBytes(length);
			if (intBuff.Length == 8)
			{
				return BitConverter.ToDouble(intBuff, 0);
			}
			else
			{
				var intFinalBuff = new byte[8];

				Array.Copy(intBuff, 0, intFinalBuff, 8 - intBuff.Length, intBuff.Length);
				return BitConverter.ToDouble(intFinalBuff, 0);
			}
		}

		private static byte[] ConvertToVarBinary(int value, out byte length)
		{
			if (value < 0)
			{
				length = 4;
				var buff = new byte[4];
				buff[0] = (byte)value;
				buff[1] = (byte)(value >> 8);
				buff[2] = (byte)(value >> 16);
				buff[3] = (byte)(value >> 24);
				return buff;
			}
			else
			{
				var buff = new byte[4];
				var num1 = (byte)value;
				var num2 = (byte)(value >> 8);
				var num3 = (byte)(value >> 16);
				var num4 = (byte)(value >> 24);


				buff[0] = num1;

				if (num2 > 0)
				{
					buff[1] = num2;
				}
				else if (num3 == 0 && num4 == 0)
				{
					Array.Resize(ref buff, 1);
					length = 1;
					return buff;
				}

				if (num3 > 0)
				{
					buff[2] = num3;
				}
				else if (num4 == 0)
				{
					Array.Resize(ref buff, 2);
					length = 2;
					return buff;
				}

				if (num4 > 0)
					buff[3] = num4;
				else
				{
					Array.Resize(ref buff, 3);
					length = 3;
					return buff;
				}
				length = 4;
				return buff;
			}
		}
		private static byte[] ConvertToVarBinary(uint value, out byte length)
		{
			if (value == 0)
			{
				length = 1;
				return new byte[] { 0 };
			}

			var buff = new byte[4];
			var num1 = (byte)value;
			var num2 = (byte)(value >> 8);
			var num3 = (byte)(value >> 16);
			var num4 = (byte)(value >> 24);


			buff[0] = num1;

			if (num2 > 0)
			{
				buff[1] = num2;
			}
			else if (num3 == 0 && num4 == 0)
			{
				Array.Resize(ref buff, 1);
				length = 1;
				return buff;
			}

			if (num3 > 0)
			{
				buff[2] = num3;
			}
			else if (num4 == 0)
			{
				Array.Resize(ref buff, 2);
				length = 2;
				return buff;
			}

			if (num4 > 0)
				buff[3] = num4;
			else
			{
				Array.Resize(ref buff, 3);
				length = 3;
				return buff;
			}
			length = 4;
			return buff;
		}

		private static byte[] ConvertToVarBinary(long value, out byte length)
		{
			var buff = new byte[8];
			buff[0] = (byte)value;
			buff[1] = (byte)(value >> 8);
			buff[2] = (byte)(value >> 16);
			buff[3] = (byte)(value >> 24);
			buff[4] = (byte)(value >> 32);
			buff[5] = (byte)(value >> 40);
			buff[6] = (byte)(value >> 48);
			buff[7] = (byte)(value >> 56);

			for (int i = 8 - 1; i >= 0; i--)
			{
				if (buff[i] > 0)
				{
					length = (byte)(i + 1);
					if (length != 8)
						Array.Resize(ref buff, length);
					return buff;
				}
			}

			length = 1;
			return new byte[] { 0 };
		}

		private static byte[] ConvertToVarBinary(ulong value, out byte length)
		{
			var buff = new byte[8];
			buff[0] = (byte)value;
			buff[1] = (byte)(value >> 8);
			buff[2] = (byte)(value >> 16);
			buff[3] = (byte)(value >> 24);
			buff[4] = (byte)(value >> 32);
			buff[5] = (byte)(value >> 40);
			buff[6] = (byte)(value >> 48);
			buff[7] = (byte)(value >> 56);

			for (int i = 8 - 1; i >= 0; i--)
			{
				if (buff[i] > 0)
				{
					length = (byte)(i + 1);
					if (length != 8)
						Array.Resize(ref buff, length);
					return buff;
				}
			}

			length = 1;
			return new byte[] { 0 };
		}

		private static byte[] ConvertToVarBinary(Int16 value, out byte length)
		{
			if (value < 0)
			{
				length = 2;
				var buff = new byte[2];
				buff[0] = (byte)value;
				buff[1] = (byte)(value >> 8);
				return buff;
			}
			else
			{
				var buff = new byte[2];
				var num1 = (byte)value;
				var num2 = (byte)(value >> 8);

				buff[0] = num1;

				if (num2 > 0)
					buff[1] = num2;
				else
				{
					Array.Resize(ref buff, 1);
					length = 1;
					return buff;
				}

				length = 2;
				return buff;
			}
		}

		private static byte[] ConvertToVarBinary(float value, out byte length)
		{
			// Float & double numeric formats stores valuable bytes from right to left

			var valueBuff = BitConverter.GetBytes(value);
			var num1 = valueBuff[0];
			var num2 = valueBuff[1];
			var num3 = valueBuff[2];
			var num4 = valueBuff[3];

			// zero
			if (num4 == 0 && num3 == 0 && num2 == 0 && num1 == 0)
			{
				length = 1;
				return new byte[] { 0 };
			}

			if (num3 == 0 && num2 == 0 && num1 == 0)
			{
				length = 1;
				return new byte[] { num4 };
			}

			if (num2 == 0 && num1 == 0)
			{
				length = 2;
				return new byte[] { num3, num4 };
			}

			if (num1 == 0)
			{
				length = 3;
				return new byte[] { num2, num3, num4 };
			}

			// no zeros
			length = 4;

			return valueBuff;
		}

		private static byte[] ConvertToVarBinary(double value, out byte length)
		{
			// Float  &double numeric formats stores valuable bytes from right to left

			var valueBuff = BitConverter.GetBytes(value);
			var num1 = valueBuff[0];
			var num2 = valueBuff[1];
			var num3 = valueBuff[2];
			var num4 = valueBuff[3];
			var num5 = valueBuff[4];
			var num6 = valueBuff[5];
			var num7 = valueBuff[6];
			var num8 = valueBuff[7];

			// zero
			if (num8 == 0 && num7 == 0 && num6 == 0 && num5 == 0 && num4 == 0 && num3 == 0 && num2 == 0 && num1 == 0)
			{
				length = 1;
				return new byte[] { 0 };
			}

			if (num7 == 0 && num6 == 0 && num5 == 0 && num4 == 0 && num3 == 0 && num2 == 0 && num1 == 0)
			{
				length = 1;
				return new byte[] { num8 };
			}

			if (num6 == 0 && num5 == 0 && num4 == 0 && num3 == 0 && num2 == 0 && num1 == 0)
			{
				length = 2;
				return new byte[] { num7, num8 };
			}

			if (num5 == 0 && num4 == 0 && num3 == 0 && num2 == 0 && num1 == 0)
			{
				length = 3;
				return new byte[] { num6, num7, num8 };
			}

			if (num4 == 0 && num3 == 0 && num2 == 0 && num1 == 0)
			{
				length = 4;
				return new byte[] { num5, num6, num7, num8 };
			}

			if (num3 == 0 && num2 == 0 && num1 == 0)
			{
				length = 5;
				return new byte[] { num4, num5, num6, num7, num8 };
			}

			if (num2 == 0 && num1 == 0)
			{
				length = 6;
				return new byte[] { num3, num4, num5, num6, num7, num8 };
			}

			if (num1 == 0)
			{
				length = 7;
				return new byte[] { num2, num3, num4, num5, num6, num7, num8 };
			}

			// no zeros
			length = 8;

			return valueBuff;
		}

		private static byte[] ConvertToVarBinary(decimal value, out byte length)
		{
			var bits = decimal.GetBits(value);
			var bitsArray = new byte[16];

			for (byte i = 0; i < bits.Length; i++)
			{
				var bytes = BitConverter.GetBytes(bits[i]);
				Array.Copy(bytes, 0, bitsArray, i * 4, 4);
			}

			// finding the empty characters
			for (int i = bitsArray.Length - 1; i >= 0; i--)
			{
				if (bitsArray[i] > 0)
				{
					length = (Byte)(i + 1);
					if (length != 16)
						Array.Resize(ref bitsArray, length);

					return bitsArray;
				}
			}
			length = 0;
			return new byte[0];
		}
	}
}

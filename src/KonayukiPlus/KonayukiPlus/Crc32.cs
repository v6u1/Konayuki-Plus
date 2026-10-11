using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace KonayukiPlus;

public sealed class Crc32 : HashAlgorithm
{
	public const uint uint_0 = 3988292384u;

	public const uint uint_1 = uint.MaxValue;

	private static uint[] uintArray_0;

	private readonly uint uint_2;

	private readonly uint[] uintArray_1;

	private uint uint_3;

	public override int HashSize => 32;

	public Crc32()
		: this(3988292384u, uint.MaxValue)
	{
	}

	public Crc32(uint P_0, uint P_1)
	{
		uintArray_1 = smethod_3(P_0);
		uint_2 = (uint_3 = P_1);
	}

	public override void Initialize()
	{
		uint_3 = uint_2;
	}

	protected override void HashCore(byte[] P_0, int P_1, int P_2)
	{
		uint_3 = smethod_4(uintArray_1, uint_3, P_0, P_1, P_2);
	}

	protected override byte[] HashFinal()
	{
		return HashValue = smethod_5(~uint_3);
	}

	public static uint smethod_0(byte[] P_0)
	{
		return smethod_1(uint.MaxValue, P_0);
	}

	public static uint smethod_1(uint P_0, byte[] P_1)
	{
		return smethod_2(3988292384u, P_0, P_1);
	}

	public static uint smethod_2(uint P_0, uint P_1, byte[] P_2)
	{
		return ~smethod_4(smethod_3(P_0), P_1, P_2, 0, P_2.Length);
	}

	private static uint[] smethod_3(uint P_0)
	{
		if (P_0 == 3988292384u && uintArray_0 != null)
		{
			return uintArray_0;
		}
		uint[] array = new uint[256];
		for (int i = 0; i < 256; i++)
		{
			uint num = (uint)i;
			for (int j = 0; j < 8; j++)
			{
				num = (((num & 1) != 1) ? (num >> 1) : ((num >> 1) ^ P_0));
			}
			array[i] = num;
		}
		if (P_0 == 3988292384u)
		{
			uintArray_0 = array;
		}
		return array;
	}

	private static uint smethod_4(uint[] P_0, uint P_1, IList<byte> P_2, int P_3, int P_4)
	{
		uint num = P_1;
		for (int i = P_3; i < P_4 - P_3; i++)
		{
			num = (num >> 8) ^ P_0[P_2[i] ^ (num & 0xFF)];
		}
		return num;
	}

	private static byte[] smethod_5(uint P_0)
	{
		byte[] bytes = BitConverter.GetBytes(P_0);
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(bytes);
		}
		return bytes;
	}

	public static string smethod_6(string P_0)
	{
		Crc32 crc = new Crc32();
		string text = string.Empty;
		using (FileStream inputStream = File.Open(P_0, FileMode.Open))
		{
			byte[] array = crc.ComputeHash(inputStream);
			foreach (byte b in array)
			{
				text += b.ToString("x2").ToLower();
			}
		}
		return text.ToUpper();
	}
}

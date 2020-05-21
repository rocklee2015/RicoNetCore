using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace S07.AspNetIdentityTest
{
	public class CryptoRandom
	{
		private static RandomNumberGenerator _rng = RandomNumberGenerator.Create();

		public static byte[] CreateRandomBytes(int length)
		{
			byte[] array = new byte[length];
			_rng.GetBytes(array);
			return array;
		}

		public static string CreateRandomKey(int length)
		{
			byte[] data = new byte[length];
			_rng.GetBytes(data);
			return Convert.ToBase64String(CreateRandomBytes(length));
		}

		public static string CreateUniqueKey(int length = 8)
		{
			return ByteArrayToString(CreateRandomBytes(length));
		}

		public static string CreateSeriesNumber(string prefix = "SW")
		{
			return string.Format("{0}{1}{2}", prefix, DateTime.Now.ToString("yyyyMMddHHmmss"), CreateUniqueKey());
		}

		internal static string ByteArrayToString(byte[] bytes)
		{
			StringBuilder stringBuilder = new StringBuilder(bytes.Length * 2);
			foreach (byte b in bytes)
			{
				stringBuilder.AppendFormat("{0:x2}", b);
			}
			return stringBuilder.ToString();
		}
	}

}

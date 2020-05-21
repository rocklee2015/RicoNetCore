using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace S07.AspNetIdentityTest
{
	public static class HashExtensions
	{
		private static byte[] Hash(this string plainText, HashAlgorithm hashAlgorithm)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(plainText);
			using (HashAlgorithm hashAlgorithm2 = hashAlgorithm ?? System.Security.Cryptography.MD5.Create())
			{
				return hashAlgorithm2.ComputeHash(bytes);
			}
		}

		/// <summary>
		/// Creates a SHA512 hash of the specified input.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns>A hash</returns>
		public static string Sha512(this string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return string.Empty;
			}
			return Convert.ToBase64String(Hash(input, SHA512.Create()));
		}

		/// <summary>
		/// Creates a SHA256 hash of the specified input.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns>A hash</returns>
		public static string Sha256(this string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return string.Empty;
			}
			return Convert.ToBase64String(Hash(input, SHA256.Create()));
		}

		/// <summary>
		/// Creates a MD5 hash of the specified input.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns>A hash</returns>
		public static string MD5(this string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return string.Empty;
			}
			return CryptoRandom.ByteArrayToString(Hash(input, System.Security.Cryptography.MD5.Create()));
		}

		/// <summary>
		/// Creates a SHA256 hash of the specified input.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns>A hash.</returns>
		public static byte[] Sha256(this byte[] input)
		{
			if (input == null)
			{
				return null;
			}
			using (SHA256 sHA = SHA256.Create())
			{
				return sHA.ComputeHash(input);
			}
		}
	}

}

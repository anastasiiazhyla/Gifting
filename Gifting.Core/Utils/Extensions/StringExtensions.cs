using System;

namespace Gifting.Core.Utils
{
	/// <summary>
	///     Provides extensions for string manipulations
	/// </summary>
	public static class StringExtensions
	{
		#region Public Methods

		/// <summary>
		///     Returns the leftmost n characters in a string.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="length">The length.</param>
		/// <returns>Whole string if its length is less or equal to the requested length, the leftmost n characters in a string otherwise</returns>
		public static string Left(this string value, int length)
		{
			return value.Length <= length ? value : value.Substring(0, length);
		}

		/// <summary>
		///     Returns the rightmost n characters in a string.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="length">The length.</param>
		/// <returns></returns>
		public static string Right(this string value, int length)
		{
			return value.Length <= length ? value : value.Substring(value.Length - length, length);
		}

		/// <summary>
		///     Pads the start of a string with a specified character up to a maximum string length.
		/// </summary>
		/// <param name="value">The string to pad.</param>
		/// <param name="maxLength">The maximum length of the padded string.</param>
		/// <param name="character">The character to add as padding.</param>
		/// <returns></returns>
		public static string PadLeftTo(this string value, int maxLength, char character)
		{
			// Determine the amount of padding to max out the length
			int padLength = (value.Length >= maxLength) ? 0 : (maxLength - value.Length);

			return GetPadding(padLength, character) + value;
		}

		/// <summary>
		///     Pads the end of a string with a specified character up to a maximum string length.
		/// </summary>
		/// <param name="value">The string to pad.</param>
		/// <param name="maxLength">The maximum length of the padded string.</param>
		/// <param name="character">The character to add as padding.</param>
		/// <returns></returns>
		public static string PadRightTo(this string value, int maxLength, char character)
		{
			// Determine the amount of padding to max out the length
			int padLength = (value.Length >= maxLength) ? 0 : (maxLength - value.Length);

			return value + GetPadding(padLength, character);
		}

		/// <summary>
		/// Compares two strings with OrdinalIgnoreCase comparison type
		/// </summary>
		public static bool IsEqualOrdinalNoCase(this string value, string str)
		{
			return value.Equals(str, StringComparison.OrdinalIgnoreCase);
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Gets the padding string.
		/// </summary>
		/// <param name="length">The number of characters to generate.</param>
		/// <param name="character">The character to use as padding.</param>
		/// <returns></returns>
		private static string GetPadding(int length, char character)
		{
			return new string(character, length);
		}

		#endregion
	}
}
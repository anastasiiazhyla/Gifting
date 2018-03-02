using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Gifting.Core.Utils
{
	/// <summary>
	/// Helper which extend enum functionality
	/// </summary>
	public static class EnumHelper
		//where T : struct
	{
		/// <summary>
		/// Get value from description attribute related to the enum
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetEnumDescription(Enum value)
		{
			FieldInfo fi = value.GetType().GetField(value.ToString());

			DescriptionAttribute[] attributes =
				(DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

			if (attributes.Any() && attributes.Length > 0)
			{
				return attributes[0].Description;
			}

			return value.ToString();
		}

		/// <summary>
		/// Parses given string to a provided enum.
		/// NOTE: Parsing is case insensitive.
		/// </summary>
		/// <param name="enumValue">String representation of the enum value.</param>
		/// <returns>Enum of type to parse to.</returns>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
		public static T Parse<T>(string enumValue)
		{
			Guard.IsNotNullOrWhiteSpace(enumValue, nameof(enumValue));

			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException("T must be an enumerated type");
			}

			return (T) Enum.Parse(typeof(T), enumValue, true);
		}

		/// <summary>
		/// Gets descriptions of list of enums
		/// </summary>
		/// <param name="enums">List of enums</param>
		/// <returns>List of descriptions</returns>
		public static List<string> ParseDescriptions<T>(IEnumerable<T> enums)
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException("T must be an enumerated type");
			}

			List<string> result = new List<string>();

			foreach (T error in enums)
			{
				string errorDescription = GetEnumDescription(error as Enum);
				result.Add(errorDescription);
			}

			return result;
		}
	}
}

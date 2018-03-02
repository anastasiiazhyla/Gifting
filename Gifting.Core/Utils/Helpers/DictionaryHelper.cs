using System;
using System.Collections.Generic;

namespace Gifting.Core.Utils
{
	/// <summary>
	/// Static class that contains methods for creating and manipulating dictionaries.
	/// </summary>
	public static class DictionaryHelper
	{
		/// <summary>
		/// Creates new dictionary whose keys are strings and are compared by ordinal case insensitive comparer.
		/// </summary>
		public static Dictionary<string, T> CaseInsensitiveDictionary<T>()
		{
			return new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase);
		}

		/// <summary>
		/// Creates new dictionary whose keys are strings and are compared by ordinal case insensitive comparer.
		/// </summary>
		public static Dictionary<string, T> CaseInsensitiveDictionary<T>(IDictionary<string, T> values)
		{
			return new Dictionary<string, T>(values, StringComparer.OrdinalIgnoreCase);
		}
	}
}

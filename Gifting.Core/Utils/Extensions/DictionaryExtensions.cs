using System.Collections.Generic;

namespace Gifting.Core.Utils.Extensions
{
	/// <summary>
	///     Provides extensions for dictionary manipulations
	/// </summary>
	public static class DictionaryExtensions
	{
		/// <summary>
		/// Get value of dictonary kay and returns null if value is not found.
		/// </summary>
		public static TValue GetValueOrNull<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key)
			where TValue : class
		{
			dict.TryGetValue(key, out TValue result);

			return result;
		}
	}
}
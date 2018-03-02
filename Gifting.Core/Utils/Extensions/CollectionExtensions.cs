using System;
using System.Collections.Generic;
using System.Linq;

namespace Gifting.Core.Utils.Extensions
{
	/// <summary>
	///     Provides extensions for collection manipulations
	/// </summary>
	public static class CollectionExtensions
	{
		/// <summary>
		/// Finds an element of arrays by string properties
		/// </summary>
		public static T FindByName<T>(this IEnumerable<T> values, Func<T, string> mapFunc, string str)
		{
			return values.FirstOrDefault(x => mapFunc(x).IsEqualOrdinalNoCase(str));
		}

		/// <summary>
		/// Splits given <see cref="ICollection{T}"/> on groups of given size.
		/// 
		/// NOTE: Last group may contain less elements than stated in group size.
		/// </summary>
		public static List<List<T>> Split<T>(this IList<T> list, int groupSize)
		{
			Guard.IsGreaterThanZero(groupSize, nameof(groupSize));
			Guard.IsNotNull(list, nameof(list));

			List<List<T>> groups = new List<List<T>>(list.Count / groupSize + 1);
			for (int i = 0; i < list.Count; i += groupSize)
			{
				List<T> groupList = new List<T>(groupSize);
				int maxGroupIndex = i + groupSize;
				for (int j = i; j < maxGroupIndex && j < list.Count; j++)
				{
					groupList.Add(list[j]);
				}

				groups.Add(groupList);
			}

			return groups;
		}

		/// <summary>
		/// Converts collection to dictionary with case insensitive string comparison.
		/// </summary>
		public static Dictionary<string, TValue> ToCaseInsensitiveDictionary<T, TValue>(this IEnumerable<T> values, Func<T, string> keySelector, Func<T, TValue> valueSelection)
		{
			return values.ToDictionary(keySelector, valueSelection, StringComparer.OrdinalIgnoreCase);
		}
	}
}

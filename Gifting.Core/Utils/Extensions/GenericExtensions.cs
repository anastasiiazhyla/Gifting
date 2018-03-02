using System.Linq;

namespace Gifting.Core.Utils.Extensions
{
	/// <summary>
	///     Provides extensions for generic types
	/// </summary>
	public static class GenericExtensions
	{
		/// <summary>
		///     Determines whether an object is in an array of objects
		/// </summary>
		/// <typeparam name="T">The object type</typeparam>
		/// <param name="value">The object to search for.</param>
		/// <param name="searchValues">The array of objects to search in.</param>
		/// <returns></returns>
		public static bool In<T>(this T value, params T[] searchValues)
		{
			return searchValues.Any(x => x.Equals(value));
		}
	}
}
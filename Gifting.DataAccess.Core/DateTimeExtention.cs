using System;
using Gifting.Core.Utils;

namespace Gifting.DataAccess.Core
{
	/// <summary>
	/// Class contains extention methods for DateTime manipulations
	/// </summary>
	public static class DateTimeExtention
	{
		/// <summary>
		/// Converts DateTimeOffset into DateTime UTC
		/// </summary>
		/// <param name="dateTimeOffset">Offset value to convert</param>
		/// <returns>DateTime with UTC kind</returns>
		public static DateTime ToUtcDateTime(this DateTimeOffset dateTimeOffset)
		{
			return dateTimeOffset.UtcDateTime;
		}

		/// <summary>
		/// Converts DateTimeOffset into DateTime UTC
		/// </summary>
		/// <param name="dateTimeOffset">Offset value to convert</param>
		/// <returns>DateTime with UTC kind</returns>
		public static DateTime? ToUtcDateTime(this DateTimeOffset? dateTimeOffset)
		{
			return dateTimeOffset?.UtcDateTime;
		}

		/// <summary>
		/// Converts DateTime UTC into DateTimeOffset
		/// </summary>
		/// <param name="dateTime">Offset value to convert</param>
		/// <returns>DateTime with UTC kind</returns>
		/// <exception cref="ArgumentException">throws in case if DateTime is not UTC</exception>
		public static DateTimeOffset ToUtcDateTimeOffset(this DateTime dateTime)
		{
			Guard.IsUtcDateTime(dateTime, nameof(dateTime));

			return new DateTimeOffset(dateTime);
		}

		/// <summary>
		/// Converts DateTime UTC into DateTimeOffset
		/// </summary>
		/// <param name="dateTime">Offset value to convert</param>
		/// <returns>DateTime with UTC kind</returns>
		/// <exception cref="ArgumentException">throws in case if DateTime is not UTC</exception>
		public static DateTimeOffset? ToUtcDateTimeOffset(this DateTime? dateTime)
		{
			if (dateTime.HasValue)
			{
				Guard.IsUtcDateTime(dateTime.Value, nameof(dateTime));

				return new DateTimeOffset(dateTime.Value);
			}

			return null;
		}
	}
}
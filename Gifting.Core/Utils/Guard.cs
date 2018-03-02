using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Gifting.Core.Utils
{
	/// <summary>
	/// Static class that contains method input argument verififcations.
	/// Should be used strictly for technical validation of method input arguments (aka code contracts valdiation).
	/// </summary>
	public static class Guard
	{
		/// <summary>
		/// Check if given argument is not null.
		/// </summary>
		/// <param name="argument">Argument to check.</param>
		/// <param name="name">Name of the argument.</param>
		/// <exception cref="ArgumentNullException">Throws <see cref="ArgumentNullException"/> if argument is null.</exception>
		public static void IsNotNull(object argument, string name)
		{
			if (argument == null)
			{
				throw new ArgumentNullException(name);
			}
		}

		/// <summary>
		/// Check if given list is not null or empty.
		/// </summary>
		/// <exception cref="ArgumentNullException"><see cref="ArgumentNullException"/> is thrown if given list is null or empty.</exception>
		public static void IsNotNullOrEmpty<T>(IList<T> argument, string name)
		{
			if (argument == null || argument.Count == 0)
			{
				throw new ArgumentNullException(name, "Argument cannot be null or empty.");
			}
		}

		/// <summary>
		/// Check if given argument is not null or empty.
		/// </summary>
		/// <exception cref="ArgumentNullException"><see cref="ArgumentNullException"/> is thrown if given argument is null or empty string.</exception>
		public static void IsNotNullOrEmpty(string argument, string name)
		{
			if (string.IsNullOrEmpty(argument))
			{
				throw new ArgumentNullException(name, "Argument cannot be null or empty string.");
			}
		}

		/// <summary>
		/// Check if given argument is not null or whitespace string.
		/// </summary>
		/// <exception cref="ArgumentNullException"><see cref="ArgumentNullException"/> is thrown if given argument is null or whitespace only string.</exception>
		public static void IsNotNullOrWhiteSpace(string argument, string name)
		{
			if (string.IsNullOrWhiteSpace(argument))
			{
				throw new ArgumentNullException(name, "Argument cannot be null or whitespace only string.");
			}
		}

		/// <summary>
		/// Guards that an object value is not empty or default
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="argument"></param>
		/// <param name="paramName"></param>
		public static void IsNotEmpty<T>(T argument, string paramName)
		{
			T empty = Activator.CreateInstance<T>();
			if (argument.Equals(empty))
			{
				throw new ArgumentNullException(paramName);
			}
		}

		/// <summary>
		/// Guards that a string value is not empty or whitespace
		/// </summary>
		/// <param name="argument"></param>
		/// <param name="paramName"></param>
		public static void IsNotEmpty(string argument, string paramName)
		{
			if (argument != null && string.IsNullOrWhiteSpace(argument))
			{
				throw new ArgumentNullException(paramName);
			}
		}

		/// <summary>
		/// Guards that an object value is null or not empty or default
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="argument"></param>
		/// <param name="paramName"></param>
		public static void IsNullOrNotEmpty<T>(T argument, string paramName)
		{
			if (argument != null)
			{
				Type type = argument.GetType().UnderlyingSystemType;

				object empty = Activator.CreateInstance(type);
				if (argument.Equals(empty))
				{
					throw new ArgumentNullException(paramName);
				}
			}
		}

		/// <summary>
		/// Checks if given list is not empty.
		/// </summary>
		/// <exception cref="ArgumentNullException"><see cref="ArgumentNullException"/> is thrown if given list is empty.</exception>
		public static void IsNotEmpty<T>(IEnumerable<T> argument, string paramName)
		{
			if (argument != null && !argument.Any())
			{
				throw new ArgumentNullException(paramName);
			}
		}

		/// <summary>
		/// Check if given argument is not null or whitespace string.
		/// </summary>
		/// <exception cref="ArgumentException"><see cref="ArgumentException"/> is thrown if given argument is not an UTC <see cref="DateTime"/>.</exception>
		public static void IsUtcDateTime(DateTime argument, string name)
		{
			if (argument.Kind != DateTimeKind.Utc)
			{
				throw new ArgumentException($"Argument [{name}] expected to be an UTC DateTime, while actual date kind is {argument.Kind}.");
			}
		}

		/// <summary>
		/// Check whether given argument is one of names of target enumeration
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		[SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
		public static void IsEnumName<TEnum>(string argument, string name)
			where TEnum : struct
		{
			if (!Enum.TryParse(argument, out TEnum _))
			{
				throw new ArgumentOutOfRangeException($"Argument [{name}] expected to be in this range: {string.Join(" | ", Enum.GetNames(typeof(TEnum)))}.");
			}
		}

		/// <summary>
		/// Checks whether given argument is greater than zero and throws excetption if it is not.
		/// </summary>
		public static void IsGreaterThanZero(object argument, string name)
		{
			decimal argumentValue = Convert.ToDecimal(argument);
			if (argumentValue <= 0)
			{
				throw new ArgumentOutOfRangeException(name, "Argument must be greater than zero.");
			}
		}

		/// <summary>
		/// Checks whether given argument is greater or equal to zero and throws excetption if it is not.
		/// </summary>
		public static void IsGreaterOrEqualToZero(object argument, string name)
		{
			decimal argumentValue = Convert.ToDecimal(argument);
			if (argumentValue < 0)
			{
				throw new ArgumentOutOfRangeException(name, "Argument must be greater or equal to zero.");
			}
		}

		/// <summary>
		/// Checks whether given argument is greater or equal to zero and throws excetption if it is not.
		/// </summary>
		public static void IsNullOrGreaterOrEqualToZero(object argument, string name)
		{
			if (argument != null)
			{
				decimal argumentValue = Convert.ToDecimal(argument);
				if (argumentValue < 0)
				{
					throw new ArgumentOutOfRangeException(name, "Argument must be greater or equal to zero.");
				}
			}
		}

		/// <summary>
		/// Checks whether given argument is less or equal to value and throws excetption if it is not.
		/// </summary>
		[SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "LessOr")]
		public static void IsLessOrEqual(decimal argument, decimal maxValue, string name)
		{
			if (argument > maxValue)
			{
				throw new ArgumentOutOfRangeException(name, "Argument must be less or equal to " + maxValue + ".");
			}
		}


		/// <summary>
		/// Checks whether given argument length is less than given max length and throws excetption if it is not.
		/// </summary>
		/// <exception cref="ArgumentException"><see cref="ArgumentException"/> is thrown if given argument length is greater than given maximum length.</exception>
		public static void IsLengthNotGreaterThan(string argument, int maxLength, string name)
		{
			if (argument != null && argument.Length > maxLength)
			{
				throw new ArgumentException(name, $"Argument length must be less than {maxLength}.");
			}
		}

		/// <summary>
		/// Verifies enumerable has no empty items
		/// </summary>
		/// <exception cref="ArgumentNullException"><see cref="ArgumentNullException"/> is thrown if given enumerable contains empty guid.</exception>
		public static void NoEmptyItems(IEnumerable<Guid> argument, string name)
		{
			if (argument != null && argument.Any(x => x == Guid.Empty))
			{
				throw new ArgumentNullException(name, "Argument cannot contain empty guid.");
			}
		}
	}
}

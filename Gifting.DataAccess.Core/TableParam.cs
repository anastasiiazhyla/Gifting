using System.Collections.Generic;
using Gifting.Core.Utils;

namespace Gifting.DataAccess.Core
{
	/// <summary>
	///     Table parameter.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class TableParam<T>
	{
		/// <summary>
		///     Constructor.
		/// </summary>
		/// <param name="paramName"></param>
		/// <param name="values"></param>
		public TableParam(string paramName, List<T> values)
		{
			Guard.IsNotNullOrEmpty(paramName, nameof(paramName));
			Guard.IsNotNull(values, nameof(values));

			ParamName = paramName;
			Values = values;
		}

		/// <summary>
		///     The name of table parameter is a stored procedure.
		/// </summary>
		private string ParamName { get; }

		/// <summary>
		///     List of values which are used as a content of a table variable
		/// </summary>
		private List<T> Values { get; }
	}
}
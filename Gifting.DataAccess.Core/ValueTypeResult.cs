namespace Gifting.DataAccess.Core
{
	/// <summary>
	/// A wrapper for value type result of query
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ValueTypeResult<T>
		where T : struct
	{
		/// <summary>
		/// Actual result value
		/// </summary>
		public T Value { get; set; }
	}
}
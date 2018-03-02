using System.Collections.Generic;

namespace Gifting.Public.ViewModels.Common
{
	public class ResponseWrapper<T> : ResponseWrapper
	{
		public T Data { get; set; }

		public ResponseWrapper(T data)
		{
			Data = data;
		}
	}

	public class ResponseWrapper
	{
		public string Message { get; set; }

		public Dictionary<string, string[]> Errors { get; set; }

		protected ResponseWrapper(){ }

		public ResponseWrapper(string message)
		{
			Message = message;
		}

		public ResponseWrapper(string message, Dictionary<string, string[]> errors) : this(message)
		{
			Errors = errors;
		}
	}
}

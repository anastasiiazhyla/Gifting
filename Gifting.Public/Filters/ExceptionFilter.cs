using System;
using System.Net;
using Gifting.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Gifting.Public.Filters
{
    public class ExceptionFilter : IExceptionFilter
	{
		public void OnException(ExceptionContext context)
		{
			HttpStatusCode status;
			string message;

			Type exceptionType = context.Exception.GetType();
			switch (exceptionType.Name)
			{
				case nameof(UnauthorizedAccessException):
					message = "Unauthorized Access";
					status = HttpStatusCode.Unauthorized;
					break;

				case nameof(NotImplementedException):
					message = "A server error occurred.";
					status = HttpStatusCode.NotImplemented;
					break;

				case nameof(EntityNotFoundException):
					message = context.Exception.Message;
					status = HttpStatusCode.NotFound;
					break;

				default:
					message = context.Exception.ToString();
					status = HttpStatusCode.InternalServerError;
					break;
			}

			context.ExceptionHandled = true;

			HttpResponse response = context.HttpContext.Response;
			response.StatusCode = (int)status;
			response.ContentType = "application/json";
			string error = message + " " + context.Exception.StackTrace;
			response.WriteAsync(error);
		}
	}
}

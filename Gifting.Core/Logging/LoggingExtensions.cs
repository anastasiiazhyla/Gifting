using System;
using Microsoft.Extensions.Logging;

namespace Gifting.Core.Logging
{
	public static class LoggingExtensions
	{
		/// <summary>
		/// Logs DB connection has been created and is going to be openned event.
		/// </summary>
		public static void LogDbRequestInitiating<T>(this ILogger<T> logger, string connectionString)
		{
			logger.LogInformation("DB request initialized.", new { ConnectionString = connectionString });
		}

		/// <summary>
		/// Logs DB request starts executing event.
		/// </summary>
		public static void LogDbRequestStarted<T>(this ILogger<T> logger, string connectionString, string storedProcedureName)
		{
			if (logger.IsEnabled(LogLevel.Trace))
			{
				logger.LogTrace("DB request started.", new { ConnectionString = connectionString, StoredProcedure = storedProcedureName });
			}
			else
			{
				logger.LogInformation("DB request started.", new { StoredProcedure = storedProcedureName });
			}
		}

		/// <summary>
		/// Logs DB request has finished executing event.
		/// </summary>
		public static void LogDbRequestFinished<T>(this ILogger<T> logger, string connectionString, string storedProcedureName, object result)
		{
			if (logger.IsEnabled(LogLevel.Trace))
			{
				logger.LogTrace("DB request finished.", new { ConnectionString = connectionString, StoredProcedure = storedProcedureName, Result = result });
			}
			else
			{
				logger.LogInformation("DB request finished.", new { StoredProcedure = storedProcedureName });
			}
		}

		/// <summary>
		/// Logs DB request processing error of any type and reason.
		/// </summary>
		public static void LogDbRequestError<T>(this ILogger<T> logger, Exception error)
		{
			logger.LogError("DB request failed.", error);
		}
	}
}

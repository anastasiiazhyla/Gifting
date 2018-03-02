using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Gifting.Core.Logging;
using Gifting.Core.Utils;
using Gifting.Models.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Gifting.DataAccess.Core
{
	/// <summary>
	/// Base Sql data access repository.
	/// </summary>
	public abstract class Repository
	{
		private readonly string _connectionString;
		private readonly ILogger<Repository> _logger;

		/// <summary>
		/// Creates new instance of repositry and initializes it to use specified DB connection string and logger.
		/// </summary>
		/// <param name="databaseOptions">database options (connection string etc.).</param>
		/// <param name="logger">Logger instance ot use for logging DB events.</param>
		protected Repository(IOptions<DatabaseOptions> databaseOptions, ILogger<Repository> logger)
		{
			Guard.IsNotNull(databaseOptions, nameof(databaseOptions));
			Guard.IsNotNullOrEmpty(databaseOptions.Value.ConnectionString, nameof(databaseOptions.Value.ConnectionString));
			Guard.IsNotNull(logger, nameof(logger));

			_connectionString = databaseOptions.Value.ConnectionString;
			_logger = logger;
		}

		/// <summary>
		/// Synchroniously executes query from stored procedure on the database and returns result.
		/// </summary>
		/// <typeparam name="TResult">Expected resulting DTO.</typeparam>
		/// <param name="storedProcedureName">Stored procedure to be executed.</param>
		/// <param name="parameters">Stored procedure parameters.</param>
		/// <returns>List of resulting records mapped to DTO objects.</returns>
		protected List<TResult> Query<TResult>(string storedProcedureName, DynamicParameters parameters)
		{
			Guard.IsNotNullOrWhiteSpace(storedProcedureName, nameof(storedProcedureName));
			Guard.IsNotNull(parameters, nameof(parameters));

			try
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					_logger.LogDbRequestInitiating(connection.ConnectionString);
					connection.Open();

					_logger.LogDbRequestStarted(connection.ConnectionString, storedProcedureName);

					IEnumerable<TResult> queryResult = connection.Query<TResult>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure, commandTimeout: int.MaxValue);
					List<TResult> result = queryResult.ToList();
					result.TrimExcess();

					_logger.LogDbRequestFinished(connection.ConnectionString, storedProcedureName, result);

					return result;
				}
			}
			catch (Exception ex)
			{
				_logger.LogDbRequestError(ex);
				throw;
			}
		}

		/// <summary>
		/// Asynchroniously executes query from stored procedure on the database and returns result.
		/// </summary>
		/// <typeparam name="TResult">Expected resulting DTO.</typeparam>
		/// <param name="storedProcedureName">Stored procedure to be executed.</param>
		/// <param name="parameters">Stored procedure parameters.</param>
		/// <returns>List of resulting records mapped to DTO objects.</returns>
		protected async Task<List<TResult>> QueryAsync<TResult>(string storedProcedureName, DynamicParameters parameters)
		{
			Guard.IsNotNullOrWhiteSpace(storedProcedureName, nameof(storedProcedureName));
			Guard.IsNotNull(parameters, nameof(parameters));

			try
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					_logger.LogDbRequestInitiating(connection.ConnectionString);
					await connection.OpenAsync();

					_logger.LogDbRequestStarted(connection.ConnectionString, storedProcedureName);

					IEnumerable<TResult> queryResult = await connection.QueryAsync<TResult>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure, commandTimeout: int.MaxValue);

					List<TResult> result = queryResult.ToList();
					result.TrimExcess();

					_logger.LogDbRequestFinished(connection.ConnectionString, storedProcedureName, result);

					return result;
				}
			}
			catch (Exception ex)
			{
				_logger.LogDbRequestError(ex);
				throw;
			}
		}

		/// <summary>
		/// Synchroniously executes query from stored procedure on the database and expects one or no resulting records.
		/// </summary>
		/// <typeparam name="TResult">Expected resulting DTO.</typeparam>
		/// <param name="storedProcedureName">Stored procedure to be executed.</param>
		/// <param name="parameters">Stored procedure parameters.</param>
		/// <returns>Resulting record mapped to DTO object or null if none found.</returns>
		protected TResult QuerySingleOrDefault<TResult>(string storedProcedureName, DynamicParameters parameters)
			where TResult : class
		{
			Guard.IsNotNullOrWhiteSpace(storedProcedureName, nameof(storedProcedureName));
			Guard.IsNotNull(parameters, nameof(parameters));

			return Query<TResult>(storedProcedureName, parameters).SingleOrDefault();
		}

		/// <summary>
		/// Asynchroniously executes query stored procedure on the database and expects one or no resulting records.
		/// </summary>
		/// <typeparam name="TResult">Expected resulting DTO.</typeparam>
		/// <param name="storedProcedureName">Stored procedure to be executed.</param>
		/// <param name="parameters">Stored procedure parameters.</param>
		/// <returns>Resulting record mapped to DTO object or null if none found.</returns>
		protected async Task<TResult> QuerySingleOrDefaultAsync<TResult>(string storedProcedureName, DynamicParameters parameters)
			where TResult : class
		{
			Guard.IsNotNullOrWhiteSpace(storedProcedureName, nameof(storedProcedureName));
			Guard.IsNotNull(parameters, nameof(parameters));

			List<TResult> result = await QueryAsync<TResult>(storedProcedureName, parameters);

			return result.SingleOrDefault();
		}

		/// <summary>
		/// Synchroniously executes query from stored procedure on the database and expects obligatory single record.
		/// </summary>
		/// <typeparam name="TResult">Expected resulting DTO.</typeparam>
		/// <param name="storedProcedureName">Stored procedure to be executed.</param>
		/// <param name="parameters">Stored procedure parameters.</param>
		/// <returns>Resulting record mapped to DTO object or null if none found.</returns>
		protected TResult QueryOne<TResult>(string storedProcedureName, DynamicParameters parameters)
		{
			Guard.IsNotNullOrWhiteSpace(storedProcedureName, nameof(storedProcedureName));
			Guard.IsNotNull(parameters, nameof(parameters));

			return Query<TResult>(storedProcedureName, parameters).Single();
		}

		/// <summary>
		/// Asynchroniously executes query stored procedure on the database and expects obligatory single record.
		/// </summary>
		/// <typeparam name="TResult">Expected resulting DTO.</typeparam>
		/// <param name="storedProcedureName">Stored procedure to be executed.</param>
		/// <param name="parameters">Stored procedure parameters.</param>
		/// <returns>Resulting record mapped to DTO object or null if none found.</returns>
		protected async Task<TResult> QueryOneAsync<TResult>(string storedProcedureName, DynamicParameters parameters)
		{
			Guard.IsNotNullOrWhiteSpace(storedProcedureName, nameof(storedProcedureName));
			Guard.IsNotNull(parameters, nameof(parameters));

			List<TResult> result = await QueryAsync<TResult>(storedProcedureName, parameters);

			return result.Single();
		}

		/// <summary>
		/// Synchroniously executes stored procedure on the database and returns number of records affected by it.
		/// </summary>
		/// <param name="storedProcedureName">Stored procedure to be executed.</param>
		/// <param name="parameters">Stored procedure parameters.</param>
		/// <returns>number of records affected by the stored procedure.</returns>
		protected int Execute(string storedProcedureName, DynamicParameters parameters)
		{
			Guard.IsNotNullOrWhiteSpace(storedProcedureName, nameof(storedProcedureName));
			Guard.IsNotNull(parameters, nameof(parameters));

			try
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					_logger.LogDbRequestInitiating(connection.ConnectionString);
					connection.Open();

					_logger.LogDbRequestStarted(connection.ConnectionString, storedProcedureName);

					int result = connection.Execute(storedProcedureName, parameters, commandType: CommandType.StoredProcedure, commandTimeout: int.MaxValue);

					_logger.LogDbRequestFinished(connection.ConnectionString, storedProcedureName, result);

					return result;
				}
			}
			catch (Exception ex)
			{
				_logger.LogDbRequestError(ex);
				throw;
			}
		}

		/// <summary>
		/// Asynchroniously executes stored procedure on the database and returns number of records affected by it.
		/// </summary>
		/// <param name="storedProcedureName">Stored procedure to be executed.</param>
		/// <param name="parameters">Stored procedure parameters.</param>
		/// <returns>number of records affected by the stored procedure.</returns>
		protected async Task<int> ExecuteAsync(string storedProcedureName, DynamicParameters parameters)
		{
			Guard.IsNotNullOrWhiteSpace(storedProcedureName, nameof(storedProcedureName));
			Guard.IsNotNull(parameters, nameof(parameters));

			try
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					_logger.LogDbRequestInitiating(connection.ConnectionString);
					await connection.OpenAsync();

					_logger.LogDbRequestStarted(connection.ConnectionString, storedProcedureName);

					int result = await connection.ExecuteAsync(storedProcedureName, parameters, commandType: CommandType.StoredProcedure, commandTimeout: int.MaxValue);

					_logger.LogDbRequestFinished(connection.ConnectionString, storedProcedureName, result);

					return result;
				}
			}
			catch (Exception ex)
			{
				_logger.LogDbRequestError(ex);
				throw;
			}
		}

		/// <summary>
		/// Asynchroniously executes stored procedure on the database and returns one scalar number returned by it.
		/// </summary>
		/// <param name="storedProcedureName">Stored procedure to be executed.</param>
		/// <param name="parameters">Stored procedure parameters.</param>
		/// <returns>Scalar number returned by stored procedure</returns>
		protected async Task<int> ExecuteScalarAsync(string storedProcedureName, DynamicParameters parameters)
		{
			Guard.IsNotNullOrWhiteSpace(storedProcedureName, nameof(storedProcedureName));
			Guard.IsNotNull(parameters, nameof(parameters));

			try
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					_logger.LogDbRequestInitiating(connection.ConnectionString);
					await connection.OpenAsync();

					_logger.LogDbRequestStarted(connection.ConnectionString, storedProcedureName);

					int result = await connection.ExecuteScalarAsync<int>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure, commandTimeout: int.MaxValue);

					_logger.LogDbRequestFinished(connection.ConnectionString, storedProcedureName, result);

					return result;
				}
			}
			catch (Exception ex)
			{
				_logger.LogDbRequestError(ex);
				throw;
			}
		}

		/// <summary>
		/// Asynchronously executes raw SQL query.
		/// WARNING: always considred using stored procedures for DB querying. This method is to be used only if SQL is generated based on query parameters.
		/// </summary>
		/// <param name="sql">SQL to execute.NOTE: DO NOT EMBED any parameter values into sql query.</param>
		/// <param name="parameters">Parameters to be passed into query.</param>
		/// <returns>Number of rows affected.</returns>
		protected async Task<int> ExecuteRawSqlAsync(string sql, DynamicParameters parameters)
		{
			Guard.IsNotNullOrWhiteSpace(sql, nameof(sql));
			Guard.IsNotNull(parameters, nameof(parameters));

			try
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					_logger.LogDbRequestInitiating(connection.ConnectionString);
					await connection.OpenAsync();

					_logger.LogDbRequestStarted(connection.ConnectionString, sql);

					int result = await connection.ExecuteScalarAsync<int>(sql, parameters, commandType: CommandType.Text, commandTimeout: int.MaxValue);

					_logger.LogDbRequestFinished(connection.ConnectionString, sql, result);

					return result;
				}
			}
			catch (Exception ex)
			{
				_logger.LogDbRequestError(ex);
				throw;
			}
		}

		/// <summary>
		/// Asynchronously performs data query based on raw SQL query.
		/// WARNING: always considred using stored procedures for DB querying. This method is to be used only if SQL is generated based on query parameters.
		/// </summary>
		/// <param name="sql">SQL to execute.NOTE: DO NOT EMBED any parameter values into sql query.</param>
		/// <param name="parameters">Parameters to be passed into query.</param>
		/// <returns>Number of rows affected.</returns>
		protected async Task<List<TResult>> QueryRawSqlAsync<TResult>(string sql, DynamicParameters parameters)
		{
			Guard.IsNotNullOrWhiteSpace(sql, nameof(sql));
			Guard.IsNotNull(parameters, nameof(parameters));

			try
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					_logger.LogDbRequestInitiating(connection.ConnectionString);
					await connection.OpenAsync();

					_logger.LogDbRequestStarted(connection.ConnectionString, sql);

					IEnumerable<TResult> queryResult = await connection.QueryAsync<TResult>(sql, parameters, commandType: CommandType.Text, commandTimeout: int.MaxValue);

					List<TResult> result = queryResult.ToList();
					result.TrimExcess();

					_logger.LogDbRequestFinished(connection.ConnectionString, sql, result);

					return result;
				}
			}
			catch (Exception ex)
			{
				_logger.LogDbRequestError(ex);
				throw;
			}
		}
	}
}

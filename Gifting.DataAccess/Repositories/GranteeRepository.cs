using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Gifting.DataAccess.Core;
using Gifting.DataAccess.Interfaces;
using Gifting.Models.Entities;
using Gifting.Models.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Gifting.DataAccess.Repositories
{
	public class GranteeRepository : Repository, IGranteeRepository
	{
		public GranteeRepository(IOptions<DatabaseOptions> databaseOptions, ILogger<GranteeRepository> logger) : base(databaseOptions, logger)
		{
		}

		public async Task<Grantee> GetById(long id)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("id", id);

			return await QuerySingleOrDefaultAsync<Grantee>(StoredProcedures.Grantee.GetById, parameters);
		}

		public async Task<Grantee> Create(Grantee grantee)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@Id", grantee.Id, DbType.Int64, ParameterDirection.Output);
			parameters.Add("@Name", grantee.Name);
			parameters.Add("@UserId", grantee.UserId);

			await ExecuteAsync(StoredProcedures.Grantee.Create, parameters);

			grantee.Id = parameters.Get<long>("@Id");

			return grantee;
		}

		public async Task<int> Update(Grantee grantee)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@Id", grantee.Id, DbType.Guid);
			parameters.Add("@Name", grantee.Name);

			int rowsAffected = await ExecuteAsync(StoredProcedures.Grantee.Update, parameters);

			return rowsAffected;
		}

		public async Task<int> Delete(long id)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@Id", id);

			int rowsAffected = await ExecuteAsync(StoredProcedures.Grantee.Delete, parameters);

			return rowsAffected;
		}

		public async Task<List<Grantee>> GetByUserId(long? userId)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("UserId", userId);

			return await QueryAsync<Grantee>(StoredProcedures.Grantee.GetByUserId, parameters);
		}
	}
}

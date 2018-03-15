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
	public class OccasionRepository : Repository, IOccasionRepository
	{
		public OccasionRepository(IOptions<DatabaseOptions> databaseOptions, ILogger<OccasionRepository> logger) : base(databaseOptions, logger)
		{
		}

		public async Task<Occasion> GetById(long id)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("id", id);

			return await QuerySingleOrDefaultAsync<Occasion>(StoredProcedures.Occasion.GetById, parameters);
		}

		public async Task<Occasion> Create(Occasion occasion)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@Id", occasion.Id, DbType.Int64, ParameterDirection.Output);
			parameters.Add("@Name", occasion.Name);
			parameters.Add("@UserId", occasion.UserId);
			parameters.Add("@Period", occasion.Period);

			await ExecuteAsync(StoredProcedures.Occasion.Create, parameters);

			occasion.Id = parameters.Get<long>("@Id");

			return occasion;
		}

		public async Task<int> Update(Occasion occasion)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@Id", occasion.Id, DbType.Guid);
			parameters.Add("@Name", occasion.Name);
			parameters.Add("@Period", occasion.Period);

			int rowsAffected = await ExecuteAsync(StoredProcedures.Occasion.Update, parameters);

			return rowsAffected;
		}

		public async Task<int> Delete(long id)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@Id", id);

			int rowsAffected = await ExecuteAsync(StoredProcedures.Occasion.Delete, parameters);

			return rowsAffected;
		}

		public async Task<List<Occasion>> GetByUserId(long? userId)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("UserId", userId);

			return await QueryAsync<Occasion>(StoredProcedures.Occasion.GetByUserId, parameters);
		}
	}
}

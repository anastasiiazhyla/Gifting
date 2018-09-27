using System.Threading.Tasks;
using Dapper;
using Gifting.DataAccess.Core;
using Gifting.Models.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Gifting.DataAccess.Interfaces;

namespace Gifting.DataAccess.Repositories
{
	public class IdeaGranteeRepository : Repository, IIdeaGranteeRepository
	{
		public IdeaGranteeRepository(IOptions<DatabaseOptions> databaseOptions, ILogger<IdeaGranteeRepository> logger) : base(databaseOptions, logger)
		{
		}

		public async Task<int> Create(long ideaId, long granteeId)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@IdeaId", ideaId);
			parameters.Add("@GranteeId", granteeId);

			int rowsAffected = await ExecuteAsync(StoredProcedures.IdeaGrantee.Create, parameters);

			return rowsAffected;
		}

		public async Task<int> Update(long ideaId, long? granteeId)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@IdeaId", ideaId);
			parameters.Add("@GranteeId", granteeId);

			int rowsAffected = await ExecuteAsync(StoredProcedures.IdeaGrantee.Update, parameters);

			return rowsAffected;
		}
	}
}

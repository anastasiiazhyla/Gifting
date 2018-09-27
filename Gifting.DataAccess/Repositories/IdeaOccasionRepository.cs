using System.Threading.Tasks;
using Dapper;
using Gifting.DataAccess.Core;
using Gifting.Models.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Gifting.DataAccess.Interfaces;

namespace Gifting.DataAccess.Repositories
{
	public class IdeaOccasionRepository : Repository, IIdeaOccasionRepository
	{
		public IdeaOccasionRepository(IOptions<DatabaseOptions> databaseOptions, ILogger<IdeaOccasionRepository> logger) : base(databaseOptions, logger)
		{
		}

		public async Task<int> Create(long ideaId, long occasionId)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@IdeaId", ideaId);
			parameters.Add("@OccasionId", occasionId);

			int rowsAffected = await ExecuteAsync(StoredProcedures.IdeaOccasion.Create, parameters);

			return rowsAffected;
		}

		public async Task<int> Update(long ideaId, long? occasionId)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@IdeaId", ideaId);
			parameters.Add("@OccasionId", occasionId);

			int rowsAffected = await ExecuteAsync(StoredProcedures.IdeaOccasion.Update, parameters);

			return rowsAffected;
		}
	}
}

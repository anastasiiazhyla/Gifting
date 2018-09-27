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
	public class IdeaRepository : Repository, IIdeaRepository
	{
		public IdeaRepository(IOptions<DatabaseOptions> databaseOptions, ILogger<IdeaRepository> logger) : base(databaseOptions, logger)
		{
		}

		public async Task<Idea> GetById(long id)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("id", id);

			return await QuerySingleOrDefaultAsync<Idea>(StoredProcedures.Idea.GetById, parameters);
		}

		public async Task<Idea> Create(Idea idea)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@Id", idea.Id, DbType.Int64, ParameterDirection.Output);
			parameters.Add("@Name", idea.Name);
			parameters.Add("@Description", idea.Description);
			parameters.Add("@DateCreated", idea.DateCreated);
			parameters.Add("@Tags", idea.Tags);
			parameters.Add("@ImageUrl", idea.ImageUrl);
			parameters.Add("@UserId", idea.UserId);
			parameters.Add("@IsApproved", idea.IsApproved);
			parameters.Add("@WhereToBuy", idea.WhereToBuy);
			await ExecuteAsync(StoredProcedures.Idea.Create, parameters);

			idea.Id = parameters.Get<long>("@Id");

			return idea;
		}

		public async Task<int> Update(Idea idea)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@Id", idea.Id);
			parameters.Add("@Name", idea.Name);
			parameters.Add("@Description", idea.Description);
			parameters.Add("@Tags", idea.Tags);
			parameters.Add("@ImageUrl", idea.ImageUrl);
			parameters.Add("@WhereToBuy", idea.WhereToBuy);

			int rowsAffected = await ExecuteAsync(StoredProcedures.Idea.Update, parameters);

			return rowsAffected;
		}

		public async Task<int> Delete(long id)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@Id", id);

			int rowsAffected = await ExecuteAsync(StoredProcedures.Idea.Delete, parameters);

			return rowsAffected;
		}

		public async Task<List<Idea>> GetAll(PagingParameters pagingParameters)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("PageNumber", pagingParameters.PageNumber);
			parameters.Add("PageSize", pagingParameters.PageSize);

			return await QueryAsync<Idea>(StoredProcedures.Idea.GetAll, parameters);
		}

		public async Task<List<Idea>> GetByUserId(long userId)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("UserId", userId);

			return await QueryAsync<Idea>(StoredProcedures.Idea.GetByUserId, parameters);
		}
	}
}

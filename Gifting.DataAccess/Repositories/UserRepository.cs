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
	public class UserRepository : Repository, IUserRepository
	{
		public UserRepository(IOptions<DatabaseOptions> databaseOptions, ILogger<UserRepository> logger) : base(databaseOptions, logger)
		{
		}

		public async Task<int> Delete(long id)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@Id", id);

			int rowsAffected = await ExecuteAsync(StoredProcedures.User.Delete, parameters);

			return rowsAffected;
		}

		public async Task<User> GetById(long id)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("id", id);

			return await QuerySingleOrDefaultAsync<User>(StoredProcedures.User.GetById, parameters);
		}

		public async Task<User> Create(User user)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@Id", user.Id, DbType.Int64, ParameterDirection.Output);
			parameters.Add("@Email", user.Email);
			parameters.Add("@FirstName", user.FirstName);
			parameters.Add("@LastName", user.LastName);
			parameters.Add("@Username", user.Username);
			parameters.Add("@PasswordHash", user.PasswordHash);

			await ExecuteAsync(StoredProcedures.User.Create, parameters);

			user.Id = parameters.Get<long>("@Id");

			return user;
		}

		public async Task<int> Update(User user)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@Id", user.Id, DbType.Guid);
			parameters.Add("@Email", user.Email);
			parameters.Add("@FirstName", user.FirstName);
			parameters.Add("@LastName", user.LastName);

			int rowsAffected = await ExecuteAsync(StoredProcedures.User.Update, parameters);

			return rowsAffected;
		}

		public async Task<User> GetByUsername(string username)
		{
			DynamicParameters parameters = new DynamicParameters();

			parameters.Add("@Username", username);

			return await QuerySingleOrDefaultAsync<User>(StoredProcedures.User.GetByUsername, parameters);
		}
	}
}

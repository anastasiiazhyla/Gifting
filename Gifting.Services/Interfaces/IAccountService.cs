using System.Threading.Tasks;
using Gifting.Models.Entities;

namespace Gifting.Services.Interfaces
{
	public interface IAccountService
	{
		Task<long> Create(User user);

		Task Delete(long id);

		Task Update(User user);

		Task<User> GetById(long id);

		Task<User> Authenticate(string username, string password);
	}
}

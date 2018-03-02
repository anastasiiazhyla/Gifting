using System.Threading.Tasks;
using Gifting.Models.Entities;

namespace Gifting.DataAccess.Interfaces
{
	public interface IUserRepository
	{
		Task<User> GetById(long id);

		Task<User> Create(User user);

		Task<int> Update(User user);

		Task<User> GetByUsername(string username);
	}
}

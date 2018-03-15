using System.Threading.Tasks;
using Gifting.DataAccess.Interfaces;
using Gifting.Models.Entities;
using Gifting.Services.Interfaces;

namespace Gifting.Services
{
	public class AccountService : IAccountService
	{
		private readonly IUserRepository _userRepository;

		public AccountService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<long> Create(User user)
		{
			user.PasswordHash = HashPassword(user.PasswordHash);
			await _userRepository.Create(user);

			return user.Id;
		}

		public async Task Delete(long id)
		{
			
		}

		public async Task Update(User user)
		{
			await _userRepository.Update(user);
		}

		public async Task<User> GetById(long id)
		{
			return await _userRepository.GetById(id);
		}

		public async Task<User> Authenticate(string username, string password)
		{
			User user = await _userRepository.GetByUsername(username);

			if (user != null && user.PasswordHash == HashPassword(password))
			{
				return user;
			}

			return null;
		}

		private string HashPassword(string password)
		{
			return password;
		}
	}
}

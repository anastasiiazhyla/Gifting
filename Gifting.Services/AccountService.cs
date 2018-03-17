using System.Threading.Tasks;
using Gifting.Core;
using Gifting.DataAccess.Interfaces;
using Gifting.Models.Entities;
using Gifting.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Gifting.Services
{
	public class AccountService : IAccountService
	{
		private readonly IUserRepository _userRepository;
		private readonly IPasswordHasher<User> _passwordHasher;

		public AccountService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
		{
			_userRepository = userRepository;
			_passwordHasher = passwordHasher;
		}

		public async Task<long> Create(User user)
		{
			user.PasswordHash = HashPassword(user, user.PasswordHash);
			await _userRepository.Create(user);

			return user.Id;
		}

		public async Task Delete(long id)
		{
			int rowsAffected = await _userRepository.Delete(id);

			if (rowsAffected == 0)
			{
				throw new EntityNotFoundException(id, typeof(User));
			}
		}

		public async Task Update(User user)
		{
			int rowsAffected = await _userRepository.Update(user);
			if (rowsAffected == 0)
			{
				throw new EntityNotFoundException(user.Id, typeof(User));
			}
		}

		public async Task<User> GetById(long id)
		{
			return await _userRepository.GetById(id);
		}

		public async Task<User> Authenticate(string username, string password)
		{
			User user = await _userRepository.GetByUsername(username);

			if (user != null && VerifyHash(user, password))
			{
				return user;
			}

			return null;
		}

		private string HashPassword(User user, string password)
		{
			return _passwordHasher.HashPassword(user, password);
		}

		private bool VerifyHash(User user, string providedPassword)
		{
			return _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, providedPassword) == PasswordVerificationResult.Success;
		}
	}
}

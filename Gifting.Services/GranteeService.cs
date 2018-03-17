using System.Collections.Generic;
using Gifting.Models.Entities;
using Gifting.Services.Interfaces;
using System.Threading.Tasks;
using Gifting.Core;
using Gifting.DataAccess.Interfaces;

namespace Gifting.Services
{
	public class GranteeService : IGranteeService
	{
		private readonly IGranteeRepository _granteeRepository;

		public GranteeService(IGranteeRepository granteeRepository)
		{
			_granteeRepository = granteeRepository;
		}

		public async Task<long> Create(Grantee grantee)
		{
			await _granteeRepository.Create(grantee);

			return grantee.Id;
		}

		public async Task Delete(long id)
		{
			int rowsAffected = await _granteeRepository.Delete(id);

			if (rowsAffected == 0)
			{
				throw new EntityNotFoundException(id, typeof(Grantee));
			}
		}

		public async Task<List<Grantee>> GetAvailable(long? userId)
		{
			List<Grantee> availableGrantee = new List<Grantee>();
			if (userId.HasValue)
			{
				List<Grantee> userGrantees = await _granteeRepository.GetByUserId(userId);
				availableGrantee.AddRange(userGrantees);
			}

			List<Grantee> commonGrantees = await _granteeRepository.GetByUserId(null);
			availableGrantee.AddRange(commonGrantees);

			return availableGrantee;
		}

		public async Task Update(Grantee grantee)
		{
			int rowsAffected = await _granteeRepository.Update(grantee);
			if (rowsAffected == 0)
			{
				throw new EntityNotFoundException(grantee.Id, typeof(Grantee));
			}
		}
	}
}
using System.Collections.Generic;
using Gifting.Models.Entities;
using Gifting.Services.Interfaces;
using System.Threading.Tasks;
using Gifting.Core;
using Gifting.DataAccess.Interfaces;

namespace Gifting.Services
{
	public class OccasionService : IOccasionService
	{
		private readonly IOccasionRepository _occasionRepository;

		public OccasionService(IOccasionRepository occasionRepository)
		{
			_occasionRepository = occasionRepository;
		}

		public async Task<long> Create(Occasion occasion)
		{
			await _occasionRepository.Create(occasion);

			return occasion.Id;
		}

		public async Task Delete(long id)
		{
			int rowsAffected = await _occasionRepository.Delete(id);

			if (rowsAffected == 0)
			{
				throw new EntityNotFoundException(id, typeof(Occasion));
			}
		}

		public async Task<List<Occasion>> GetAvailable(long? userId)
		{
			List<Occasion> availableOccasion = new List<Occasion>();
			if (userId.HasValue)
			{
				List<Occasion> userOccasions = await _occasionRepository.GetByUserId(userId);
				availableOccasion.AddRange(userOccasions);
			}

			List<Occasion> commonOccasions = await _occasionRepository.GetByUserId(null);
			availableOccasion.AddRange(commonOccasions);

			return availableOccasion;
		}

		public async Task Update(Occasion occasion)
		{
			int rowsAffected = await _occasionRepository.Update(occasion);
			if (rowsAffected == 0)
			{
				throw new EntityNotFoundException(occasion.Id, typeof(Occasion));
			}
		}
	}
}
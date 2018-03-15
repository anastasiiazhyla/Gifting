using System.Collections.Generic;
using Gifting.Models.Entities;
using Gifting.Services.Interfaces;
using System.Threading.Tasks;
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

		public void Delete(long id)
		{
			_occasionRepository.Delete(id);

			//if (removedElementsCount == 0)
			//{
			//	throw new EntityNotFoundException(id, typeof(Occasion));
			//}
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

		public void Update(Occasion occasion)
		{
			_occasionRepository.Update(occasion);
			//if (item == null)
			//{
			//	throw new EntityNotFoundException(occasion.Id, typeof(Occasion));
			//}

			//item.Name = occasion.Name;
			//item.Description = occasion.Description;
			//item.OccasionId = occasion.OccasionId;
			//item.ImageUrl = occasion.ImageUrl;
			//item.OccasionId = occasion.OccasionId;
			//item.WhereToBuy = occasion.WhereToBuy;
		}
	}
}
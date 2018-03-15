using System.Collections.Generic;
using System.Threading.Tasks;
using Gifting.Models.Entities;

namespace Gifting.Services.Interfaces
{
	public interface IOccasionService
	{
		Task<long> Create(Occasion occasion);

		void Delete(long id);

		void Update(Occasion occasion);

		Task<List<Occasion>> GetAvailable(long? userId);
	}
}
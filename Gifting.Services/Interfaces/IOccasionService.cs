using System.Collections.Generic;
using System.Threading.Tasks;
using Gifting.Models.Entities;

namespace Gifting.Services.Interfaces
{
	public interface IOccasionService
	{
		Task<long> Create(Occasion occasion);

		Task Delete(long id);

		Task Update(Occasion occasion);

		Task<List<Occasion>> GetAvailable(long? userId);
	}
}
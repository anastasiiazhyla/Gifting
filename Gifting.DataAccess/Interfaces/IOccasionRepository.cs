using System.Collections.Generic;
using System.Threading.Tasks;
using Gifting.Models.Entities;

namespace Gifting.DataAccess.Interfaces
{
	public interface IOccasionRepository
	{
		Task<Occasion> GetById(long id);

		Task<Occasion> Create(Occasion occasion);

		Task<int> Update(Occasion occasion);

		Task<int> Delete(long id);

		Task<List<Occasion>> GetByUserId(long? userId);
	}
}

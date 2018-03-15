using System.Collections.Generic;
using System.Threading.Tasks;
using Gifting.Models.Entities;

namespace Gifting.Services.Interfaces
{
	public interface IGranteeService
	{
		Task<long> Create(Grantee grantee);

		void Delete(long id);

		void Update(Grantee grantee);

		Task<List<Grantee>> GetAvailable(long? userId);
	}
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Gifting.Models.Entities;

namespace Gifting.DataAccess.Interfaces
{
	public interface IGranteeRepository
	{
		Task<Grantee> GetById(long id);

		Task<Grantee> Create(Grantee grantee);

		Task<int> Update(Grantee grantee);

		Task<int> Delete(long id);

		Task<List<Grantee>> GetByUserId(long? userId);
	}
}

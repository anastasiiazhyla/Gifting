using System.Threading.Tasks;

namespace Gifting.DataAccess.Interfaces
{
	public interface IIdeaGranteeRepository
	{
		Task<int> Create(long ideaId, long granteeId);

		Task<int> Update(long ideaId, long? granteeId);
	}
}
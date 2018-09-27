using System.Threading.Tasks;

namespace Gifting.DataAccess.Interfaces
{
	public interface IIdeaOccasionRepository
	{
		Task<int> Create(long ideaId, long occasionId);

		Task<int> Update(long ideaId, long? occasionId);
	}
}
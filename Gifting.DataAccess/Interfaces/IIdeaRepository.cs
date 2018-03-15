using System.Collections.Generic;
using System.Threading.Tasks;
using Gifting.Models.Entities;
using Gifting.Models.Models;

namespace Gifting.DataAccess.Interfaces
{
	public interface IIdeaRepository
	{
		Task<Idea> GetById(long id);

		Task<Idea> Create(Idea idea);

		Task<int> Update(Idea idea);

		Task<int> Delete(long id);

		Task<List<Idea>> GetAll(PagingParameters pagingParameters);

		Task<List<Idea>> GetByUserId(long userId);
	}
}

using System.Collections.Generic;
using Gifting.Models.Entities;
using System.Threading.Tasks;
using Gifting.Models.Models;

namespace Gifting.Services.Interfaces
{
	public interface IIdeaService
	{
		Task<long> Create(Idea idea);

		Task Delete(long id);

		Task Update(Idea idea);

		Task<List<Idea>> GetAll(PagingParameters pagingParameters);

		Task<Idea> GetById(long id);

		Task<List<Idea>> GetByUserId(long userId);
	}
}
using System.Collections.Generic;
using Gifting.Models.Entities;
using System.Threading.Tasks;
using Gifting.Models.Models;

namespace Gifting.Services.Interfaces
{
	public interface IIdeaService
	{
		Task<long> Create(Idea idea);

		void Delete(long id);

		void Update(Idea idea);

		Task<List<Idea>> GetAll(PagingParameters pagingParameters);

		Task<Idea> GetById(long id);

		Task<List<Idea>> GetByUserId(long userId);
	}
}
using System.Collections.Generic;
using Gifting.Models.Entities;

namespace Gifting.Services.Interfaces
{
	public interface IIdeasService
	{
		int Create(Idea idea);

		void Delete(int id);

		void Update(Idea idea);

		List<Idea> GetAll();

		Idea GetById(int id);

		List<Idea> GetByUserId(int userId);
	}
}
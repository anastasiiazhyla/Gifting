using System;
using System.Collections.Generic;
using Gifting.Models.Entities;
using Gifting.Services.Interfaces;
using System.Threading.Tasks;
using Gifting.DataAccess.Interfaces;
using Gifting.Models.Models;

namespace Gifting.Services
{
	public class IdeaService : IIdeaService
	{
		private readonly IIdeaRepository _ideaRepository;

		public IdeaService(IIdeaRepository ideaRepository)
		{
			_ideaRepository = ideaRepository;
		}

		public async Task<long> Create(Idea idea)
		{
			idea.DateCreated = DateTime.Now;
			await _ideaRepository.Create(idea);

			return idea.Id;
		}

		public void Delete(long id)
		{
			_ideaRepository.Delete(id);

			//if (removedElementsCount == 0)
			//{
			//	throw new EntityNotFoundException(id, typeof(Idea));
			//}
		}

		public async Task<List<Idea>> GetAll(PagingParameters pagingParameters)
		{
			return await _ideaRepository.GetAll(pagingParameters);
		}

		public async Task<Idea> GetById(long id)
		{
			return await _ideaRepository.GetById(id);
		}

		public async Task<List<Idea>> GetByUserId(long userId)
		{
			return await _ideaRepository.GetByUserId(userId); ;
		}

		public void Update(Idea idea)
		{
			_ideaRepository.Update(idea);
			//if (item == null)
			//{
			//	throw new EntityNotFoundException(idea.Id, typeof(Idea));
			//}

			//item.Name = idea.Name;
			//item.Description = idea.Description;
			//item.GranteeId = idea.GranteeId;
			//item.ImageUrl = idea.ImageUrl;
			//item.OccasionId = idea.OccasionId;
			//item.WhereToBuy = idea.WhereToBuy;
		}
	}
}
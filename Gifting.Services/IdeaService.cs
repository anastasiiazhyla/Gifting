using System;
using System.Collections.Generic;
using Gifting.Models.Entities;
using Gifting.Services.Interfaces;
using System.Threading.Tasks;
using Gifting.Core;
using Gifting.DataAccess.Interfaces;
using Gifting.Models.Models;

namespace Gifting.Services
{
	public class IdeaService : IIdeaService
	{
		private readonly IIdeaRepository _ideaRepository;
		private readonly IIdeaGranteeRepository _ideaGranteeRepository;
		private readonly IIdeaOccasionRepository _ideaOccasionRepository;

		public IdeaService(
			IIdeaRepository ideaRepository,
			IIdeaGranteeRepository ideaGranteeRepository,
			IIdeaOccasionRepository ideaOccasionRepository)
		{
			_ideaRepository = ideaRepository;
			_ideaGranteeRepository = ideaGranteeRepository;
			_ideaOccasionRepository = ideaOccasionRepository;
		}

		public async Task<long> Create(Idea idea)
		{
			idea.DateCreated = DateTime.Now;
			await _ideaRepository.Create(idea);

			if (idea.GranteeId.HasValue)
			{
				await _ideaGranteeRepository.Create(idea.Id, idea.GranteeId.Value);
			}

			if (idea.OccasionId.HasValue)
			{
				await _ideaOccasionRepository.Create(idea.Id, idea.OccasionId.Value);
			}

			return idea.Id;
		}

		public async Task Delete(long id)
		{
			int rowsAffected = await _ideaRepository.Delete(id);

			if (rowsAffected == 0)
			{
				throw new EntityNotFoundException(id, typeof(Idea));
			}
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

		public async Task Update(Idea idea)
		{
			int rowsAffected = await _ideaRepository.Update(idea);
			if (rowsAffected == 0)
			{
				throw new EntityNotFoundException(idea.Id, typeof(Idea));
			}
		}
	}
}
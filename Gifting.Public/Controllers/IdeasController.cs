using System.Collections.Generic;
using Gifting.Core.Logging;
using Gifting.Models.Entities;
using Gifting.Public.Mappers;
using Gifting.Public.ViewModels.Ideas;
using Gifting.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Gifting.Models.Models;

namespace Gifting.Public.Controllers
{
	[Authorize]
	public class IdeasController : BaseApiController
	{
		private readonly IIdeaService _ideaService;
		private readonly ILogger<IdeasController> _logger;

		public IdeasController(IIdeaService ideasService, ILogger<IdeasController> logger)
		{
			_ideaService = ideasService;
			_logger = logger;
		}

		[HttpGet("[action]")]
		public async Task<IActionResult> GetMy()
		{
			List<Idea> ideas = await _ideaService.GetByUserId(CurrentUserId.Value);

			return Success(ideas.MapList(IdeaModelMapper.MapToIdeaResponseViewModel));
		}

		[HttpGet, AllowAnonymous]
		public async Task<IActionResult> GetAll(PagingParameters pagingParameters)
		{
			List<Idea> ideas = await _ideaService.GetAll(pagingParameters);

			return Success(ideas.MapList(IdeaModelMapper.MapToIdeaResponseViewModel));
		}

		[HttpGet("{id}", Name = "GetById")]
		public async Task<IActionResult> GetById(int id)
		{
			Idea item = await _ideaService.GetById(id);
			if (item == null)
			{
				_logger.LogWarning(LoggingEvents.Warning.GetItemNotFound, $"Idea id={id} not found");
				return NotFound();
			}

			return Success(item);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateIdeaRequestViewModel createIdeaViewModel)
		{
			if (ModelState.IsValid)
			{
				Idea item = IdeaModelMapper.BuildIdeaModel(createIdeaViewModel);
				item.Id = await _ideaService.Create(item);

				return CreatedAtRoute("GetById", new { id = item.Id }, item);
			}

			return Error(ModelState);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(long id, [FromBody] UpdateIdeaRequestViewModel updateIdeaViewModel)
		{

			if (ModelState.IsValid)
			{
				Idea item = IdeaModelMapper.BuildIdeaModel(updateIdeaViewModel);

				await _ideaService.Update(item);

				return new NoContentResult();
			}

			return Error(ModelState);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _ideaService.Delete(id);

			return new NoContentResult();

			// todo: return NotFound();
		}
	}
}

using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Gifting.Core.Logging;
using Gifting.Models.Entities;
using Gifting.Public.Mappers;
using Gifting.Public.ViewModels.Ideas;
using Gifting.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Gifting.Public.Controllers
{
	[Authorize]
	public class IdeasController : BaseApiController
	{
		private readonly IIdeasService _ideasService;
		private readonly ILogger<IdeasController> _logger;

		public IdeasController(IIdeasService ideasService, ILogger<IdeasController> logger)
		{
			_ideasService = ideasService;
			_logger = logger;
		}

		[HttpGet("[action]")]
		public IEnumerable<IdeaResponseViewModel> GetMy()
		{
			ClaimsPrincipal currentUser = HttpContext.User;

			int userId = int.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti)?.Value);

			return _ideasService.GetByUserId(userId).Select(IdeaModelMapper.MapToIdeaResponseViewModel).ToList();
		}

		[HttpGet, AllowAnonymous]
		public IEnumerable<IdeaResponseViewModel> GetAll()
		{
			return _ideasService.GetAll().Select(IdeaModelMapper.MapToIdeaResponseViewModel).ToList();
		}

		[HttpGet("{id}", Name = "GetById")]
		public IActionResult GetById(int id)
		{
			Idea item = _ideasService.GetById(id);
			if (item == null)
			{
				_logger.LogWarning(LoggingEvents.Warning.GetItemNotFound, $"Idea id={id} not found");
				return NotFound();
			}

			return new ObjectResult(item);
		}

		[HttpPost]
		public IActionResult Create([FromBody] CreateIdeaRequestViewModel createIdeaViewModel)
		{
			Idea item = IdeaModelMapper.BuildIdeaModel(createIdeaViewModel);
			item.Id = _ideasService.Create(item);

			return CreatedAtRoute("GetById", new { id = item.Id }, item);
		}

		[HttpPut("{id}")]
		public IActionResult Update(long id, [FromBody] UpdateIdeaRequestViewModel updateIdeaViewModel)
		{
			Idea item = IdeaModelMapper.BuildIdeaModel(updateIdeaViewModel);

			_ideasService.Update(item);

			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_ideasService.Delete(id);

			return new NoContentResult();

			// todo: return NotFound();
		}
	}
}

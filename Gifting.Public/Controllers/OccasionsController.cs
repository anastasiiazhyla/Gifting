using System.Collections.Generic;
using System.Threading.Tasks;
using Gifting.Models.Entities;
using Gifting.Public.Mappers;
using Gifting.Public.ViewModels.Common;
using Gifting.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Gifting.Public.Controllers
{
	public class OccasionsController : BaseApiController
	{
		private readonly IOccasionService _occasionService;
		private readonly ILogger<OccasionsController> _logger;

		public OccasionsController(IOccasionService occasionService, ILogger<OccasionsController> logger)
		{
			_occasionService = occasionService;
			_logger = logger;
		}

		[HttpGet]
		public async Task<IActionResult> GetAvailable()
		{
			List<Occasion> occasions = await _occasionService.GetAvailable(CurrentUserId);

			List<DropdownItemViewModel> list = occasions.MapList(x => x.MapToDropdownItemViewModel(y => y.Id, y => y.Name));

			return Success(list);
		}
	}
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gifting.Models.Entities;
using Gifting.Public.Mappers;
using Gifting.Public.ViewModels.Common;
using Gifting.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Gifting.Public.Controllers
{
	public class GranteesController : BaseApiController
	{
		private readonly IGranteeService _granteeService;
		private readonly ILogger<GranteesController> _logger;

		public GranteesController(IGranteeService granteeService, ILogger<GranteesController> logger)
		{
			_granteeService = granteeService;
			_logger = logger;
		}

		[HttpGet]
		public async Task<IActionResult> GetAvailable()
		{
			List<Grantee> grantees = await _granteeService.GetAvailable(CurrentUserId);

			List<DropdownItemViewModel> list = grantees.MapList(x => x.MapToDropdownItemViewModel(y => y.Id, y => y.Name));

			return Success(list);
		}
	}
}

using System.Collections.Generic;
using Gifting.Public.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;

namespace Gifting.Public.Controllers
{
	public class OccasionsController : BaseApiController
	{
		[HttpGet]
		public IEnumerable<DropdownItemViewModel> GetAll()
		{
			List<DropdownItemViewModel> list = new List<DropdownItemViewModel>
			{
				new DropdownItemViewModel(1, "Birthday"),
				new DropdownItemViewModel(2, "New Year"),
				new DropdownItemViewModel(3, "Wedding")
			};

			return list;
		}
	}
}

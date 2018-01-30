using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Gifting.Public.ViewModels.Common;

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

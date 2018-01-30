using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Gifting.Public.ViewModels.Common;

namespace Gifting.Public.Controllers
{
	public class GranteesController : BaseApiController
	{
		[HttpGet]
		public IEnumerable<DropdownItemViewModel> GetAll()
		{
			List<DropdownItemViewModel> list = new List<DropdownItemViewModel>
			{
				new DropdownItemViewModel(1, "Mom"),
				new DropdownItemViewModel(2, "Dad"),
				new DropdownItemViewModel(3, "Wife"),
				new DropdownItemViewModel(4, "Husband")
			};

			return list;
		}
	}
}

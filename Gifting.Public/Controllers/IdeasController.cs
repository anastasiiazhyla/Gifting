using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Gifting.Public.ViewModels.Ideas;
using System.Linq;

namespace Gifting.Public.Controllers
{
	public class IdeasController : BaseApiController
	{
		private static List<IdeaViewModel> _list = new List<IdeaViewModel>
			{
				new IdeaViewModel { Id = 1, Name = "Book", DateCreated = DateTime.Now.AddMonths(-1) },
				new IdeaViewModel { Id = 23, Name = "Tea set", DateCreated = DateTime.Now.AddDays(-1) }
			};

		[HttpGet]
		public IEnumerable<IdeaViewModel> GetAll()
		{
			return _list;
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var item = _list.FirstOrDefault(t => t.Id == id);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}

		[HttpPost]
		public IActionResult Create([FromBody]CreateIdeaViewModel createIdeaViewModel)
		{
			//IdeaViewModel item = new IdeaViewModel
			//{
			//	Id = new Random().Next(),
			//	Name = createIdeaViewModel.Name,
			//	Description = createIdeaViewModel.Description,
			//	GranteeId = createIdeaViewModel.GranteeId,
			//	Image = createIdeaViewModel.Image,
			//	OccasionId = createIdeaViewModel.OccasionId,
			//	WhereToBuy = createIdeaViewModel.WhereToBuy,
			//	DateCreated = DateTime.Now
			//};
			//_list.Add(item);

			//return CreatedAtRoute("GetById", new { id = item.Id }, item);

			return new NoContentResult();
		}

		[HttpPut("{id}")]
		public IActionResult Update(long id, [FromBody]UpdateIdeaViewModel updateIdeaViewModel)
		{
			var item = _list.FirstOrDefault(t => t.Id == id);
			if (item == null)
			{
				return NotFound();
			}

			item.Name = updateIdeaViewModel.Name;
			item.Description = updateIdeaViewModel.Description;
			item.GranteeId = updateIdeaViewModel.GranteeId;
			item.Image = updateIdeaViewModel.Image;
			item.OccasionId = updateIdeaViewModel.OccasionId;
			item.WhereToBuy = updateIdeaViewModel.WhereToBuy;

			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var item = _list.FirstOrDefault(t => t.Id == id);
			if (item == null)
			{
				return NotFound();
			}

			_list.Remove(item);

			return new NoContentResult();
		}
	}
}

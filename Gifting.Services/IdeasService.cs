using System;
using System.Collections.Generic;
using System.Linq;
using Gifting.Core;
using Gifting.Models;
using Gifting.Models.Entities;
using Gifting.Services.Interfaces;

namespace Gifting.Services
{
	public class IdeasService : IIdeasService
	{
		private static readonly List<Idea> List = new List<Idea>
		{
			new Idea { Id = 1, Name = "Book", DateCreated = DateTime.Now.AddMonths(-1) },
			new Idea { Id = 23, Name = "Tea set", DateCreated = DateTime.Now.AddDays(-1) }	,
			new Idea { Id = 45, Name = "Notebook", DateCreated = DateTime.Now.AddDays(-10) },
			new Idea { Id = 152, Name = "Candles", DateCreated = DateTime.Now.AddDays(-45) }
		};

		public int Create(Idea idea)
		{
			idea.Id = new Random().Next();
			idea.DateCreated = DateTime.Now;
			List.Add(idea);

			return idea.Id;
		}

		public void Delete(int id)
		{
			int removedElementsCount = List.RemoveAll(x => x.Id == id);

			if (removedElementsCount == 0)
			{
				throw new EntityNotFoundException(id, typeof(Idea));
			}
		}

		public List<Idea> GetAll()
		{
			return List;
		}

		public Idea GetById(int id)
		{
			return List.FirstOrDefault(t => t.Id == id);
		}

		public List<Idea> GetByUserId(int userId)
		{
			return List.Take(3).ToList();
		}

		public void Update(Idea idea)
		{
			Idea item = List.FirstOrDefault(t => t.Id == idea.Id);
			if (item == null)
			{
				throw new EntityNotFoundException(idea.Id, typeof(Idea));
			}

			item.Name = idea.Name;
			item.Description = idea.Description;
			item.GranteeId = idea.GranteeId;
			item.Image = idea.Image;
			item.OccasionId = idea.OccasionId;
			item.WhereToBuy = idea.WhereToBuy;
		}
	}
}
using System;

namespace Gifting.Models.Entities
{
	public class Idea
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Image { get; set; }

		public string WhereToBuy { get; set; }

		public int? OccasionId { get; set; }

		public int? GranteeId { get; set; }

		public DateTime DateCreated { get; set; }
	}
}
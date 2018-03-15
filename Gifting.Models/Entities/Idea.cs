using System;

namespace Gifting.Models.Entities
{
	public class Idea
	{
		public long Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string ImageUrl { get; set; }

		public string WhereToBuy { get; set; }

		public long? OccasionId { get; set; }

		public long? GranteeId { get; set; }

		public DateTime DateCreated { get; set; }

		public string Tags { get; set; }

		public long? UserId { get; set; }

		public bool IsApproved { get; set; }
	}
}
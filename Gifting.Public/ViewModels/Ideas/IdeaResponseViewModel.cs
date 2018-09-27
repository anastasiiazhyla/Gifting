using System;

namespace Gifting.Public.ViewModels.Ideas
{
	public class IdeaResponseViewModel
	{
		public IdeaResponseViewModel(
			long id,
			string name,
			string description,
			string imageUrl,
			string whereToBuy,
			long? occasionId,
			long? granteeId,
			DateTime dateCreated)
		{
			Id = id;
			Name = name;
			Description = description;
			ImageUrl = imageUrl;
			WhereToBuy = whereToBuy;
			OccasionId = occasionId;
			GranteeId = granteeId;
			DateCreated = dateCreated;
		}

		public long Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string ImageUrl { get; set; }

		public string WhereToBuy { get; set; }

		public long? OccasionId { get; set; }

		public long? GranteeId { get; set; }

		public DateTime DateCreated { get; set; }
	}
}

using System;

namespace Gifting.Public.ViewModels.Ideas
{
	public class IdeaResponseViewModel
	{
		public IdeaResponseViewModel(
			int id,
			string name,
			string description,
			string image,
			string whereToBuy,
			int? occasionId,
			int? granteeId,
			DateTime dateCreated)
		{
			Id = id;
			Name = name;
			Description = description;
			Image = image;
			WhereToBuy = whereToBuy;
			OccasionId = occasionId;
			GranteeId = granteeId;
			DateCreated = dateCreated;
		}

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

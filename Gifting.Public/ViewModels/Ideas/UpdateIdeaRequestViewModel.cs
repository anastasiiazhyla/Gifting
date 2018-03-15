namespace Gifting.Public.ViewModels.Ideas
{
	public class UpdateIdeaRequestViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string ImageUrl { get; set; }

		public string WhereToBuy { get; set; }

		public int? OccasionId { get; set; }

		public int? GranteeId { get; set; }
	}
}

namespace Gifting.Public.ViewModels.Ideas
{
	public class UpdateIdeaViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public string WhereToBuy { get; set; }
		public int? OccasionId { get; set; }
		public int? GranteeId { get; set; }
	}
}

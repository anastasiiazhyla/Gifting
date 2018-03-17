using System.ComponentModel.DataAnnotations;

namespace Gifting.Public.ViewModels.Ideas
{
	public class UpdateIdeaRequestViewModel
	{
		public int Id { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		public string Description { get; set; }

		[Url]
		public string ImageUrl { get; set; }

		public string WhereToBuy { get; set; }

		public long? OccasionId { get; set; }

		public long? GranteeId { get; set; }
	}
}

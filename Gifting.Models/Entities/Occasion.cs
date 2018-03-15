using Gifting.Models.Enums;

namespace Gifting.Models.Entities
{
	public class Occasion
	{
		public long Id { get; set; }

		public string Name { get; set; }

		public long? UserId { get; set; }

		public OccasionPeriod Period { get; set; }
	}
}

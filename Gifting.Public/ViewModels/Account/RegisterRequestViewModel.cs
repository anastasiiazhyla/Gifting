using System.ComponentModel.DataAnnotations;

namespace Gifting.Public.ViewModels.Account
{
	public class RegisterRequestViewModel
	{
		[Required]
		public string FirstName { get; set; }

		[Required]
		[StringLength(255)]
		public string LastName { get; set; }

		[Required]
		[EmailAddress]
		[StringLength(255)]
		public string Email { get; set; }

		[Required]
		[StringLength(255, MinimumLength = 6)]
		public string Username { get; set; }

		[Required]
		[StringLength(255, MinimumLength = 6)]
		public string Password { get; set; }
	}
}

using System.ComponentModel.DataAnnotations;

namespace Gifting.Public.ViewModels.Account
{
	public class LoginRequestViewModel
	{
		[Required]
		public string Username { get; set; }

		[Required]
		public string Password { get; set; }
	}
}

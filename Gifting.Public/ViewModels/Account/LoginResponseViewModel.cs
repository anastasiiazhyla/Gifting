using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Gifting.Public.ViewModels.Account
{
	public class LoginResponseViewModel
	{
		public LoginResponseViewModel(string token, DateTime validTo, IEnumerable<Claim> claims)
		{
			Token = token;
			Expiration = validTo;
			Claims = claims.Select(x => new ClaimModel(x.Type, x.Value));
		}

		public string Token { get; set; }

		public DateTime Expiration { get; set; }

		public IEnumerable<ClaimModel> Claims { get; set; }
	}
}

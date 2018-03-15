using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Gifting.Public.ViewModels.Account;
using Gifting.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using Gifting.Models.Entities;
using Gifting.Public.Models;

namespace Gifting.Public.Controllers
{
	[Authorize]
	public class AccountController : BaseApiController
	{
		private readonly IAccountService _accountService;
		private readonly JWTSettings _jwtSettings;
		//private readonly SignInManager<IdentityUser> _signInManager;
		//private readonly UserManager<IdentityUser> _userManager;

		public AccountController(
			IAccountService accountService,
			//UserManager<IdentityUser> userManager,
			//SignInManager<IdentityUser> signInManager,
			IOptions<JWTSettings> optionsAccessor)
		{
			_accountService = accountService;
			_jwtSettings = optionsAccessor.Value;
			//_userManager = userManager;
			//_signInManager = signInManager;
		}

		[AllowAnonymous]
		[HttpPost("[action]")]
		public async Task<IActionResult> Login([FromBody] LoginRequestViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				ClaimsIdentity identity = await Authenticate(viewModel);

				if (identity == null)
				{
					return Unauthorized();
				}

				JwtSecurityToken jwtSecurityToken = BuildToken(_jwtSettings, identity);

				LoginResponseViewModel response = new LoginResponseViewModel(new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken), jwtSecurityToken.ValidTo, jwtSecurityToken.Claims);

				return Success(response);
			}

			return Error(ModelState);
		}

		[AllowAnonymous]
		[HttpPost("[action]")]
		public async Task<IActionResult> Register([FromBody] RegisterRequestViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				User user = new User(viewModel.FirstName, viewModel.LastName, viewModel.Email, viewModel.Username, viewModel.Password);
				//ModelState.AddModelError("emailAddress", "This email already exists");

				await _accountService.Create(user);

				ClaimsIdentity identity = BuildClaimsIdentity(user);

				if (identity == null)
				{
					return Unauthorized();
				}

				JwtSecurityToken jwtSecurityToken = BuildToken(_jwtSettings, identity);

				RegisterResponseViewModel response = new RegisterResponseViewModel(new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken), jwtSecurityToken.ValidTo, jwtSecurityToken.Claims);

				return Success(response);
			}

			return Error(ModelState);
		}

		private async Task<ClaimsIdentity> Authenticate(LoginRequestViewModel viewModel)
		{
			User user = await _accountService.Authenticate(viewModel.Username, viewModel.Password);

			if (user == null)
			{
				return null;
			}

			return BuildClaimsIdentity(user);
		}

		private ClaimsIdentity BuildClaimsIdentity(User user)
		{
			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
				new Claim(ClaimsIdentity.DefaultRoleClaimType, "user"),

				new Claim("id", user.Id.ToString()),
				new Claim("email", user.Email),
				new Claim("name", $"{user.FirstName} {user.LastName}")
			};

			ClaimsIdentity claimsIdentity = new ClaimsIdentity(
				claims,
				"Token",
				ClaimsIdentity.DefaultNameClaimType,
				ClaimsIdentity.DefaultRoleClaimType);

			return claimsIdentity;
		}

		private JwtSecurityToken BuildToken(JWTSettings jwtSettings, ClaimsIdentity identity)
		{
			SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
			SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			DateTime utcNow = DateTime.UtcNow;
			JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
				jwtSettings.Issuer,
				jwtSettings.Audience,
				identity.Claims,
				utcNow,
				utcNow.AddMinutes(jwtSettings.Lifetime),
				creds);

			return jwtSecurityToken;
		}

		//private JsonResult Error(string message)
		//{
		//	return new JsonResult(message) { StatusCode = 400 };
		//}
	}
}

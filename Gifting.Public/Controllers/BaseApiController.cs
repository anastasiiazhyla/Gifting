using System.Linq;
using System.Security.Claims;
using Gifting.Public.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Gifting.Public.Controllers
{
	[Route("api/[controller]")]
	[Produces("application/json")]
	public abstract class BaseApiController : Controller
	{
		protected OkObjectResult Success<T>(T data)
		{
			return Ok(new ResponseWrapper<T>(data));
		}

		protected BadRequestObjectResult Error(ModelStateDictionary modelState)
		{
			return BadRequest(modelState);
		}

		protected long? CurrentUserId
		{
			get
			{
				ClaimsPrincipal currentUser = HttpContext.User;
				if (currentUser == null)
				{
					return null;
				}

				string idString = currentUser.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
				long.TryParse(idString, out long userId);

				return userId;
			}
		}
	}
}

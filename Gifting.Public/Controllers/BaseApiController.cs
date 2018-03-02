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
  }
}

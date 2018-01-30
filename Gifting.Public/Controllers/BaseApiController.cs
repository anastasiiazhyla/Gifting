using Microsoft.AspNetCore.Mvc;

namespace Gifting.Public.Controllers
{
	[Route("api/[controller]")]
	[Produces("application/json")]
	public abstract class BaseApiController : Controller
	{
	}
}

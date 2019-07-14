using System.Threading.Tasks;
using EatParser.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EatParser.Api.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class YaposhkaController : ControllerBase
	{
		private readonly IYaposhkaService _service;

		public YaposhkaController(IYaposhkaService service)
		{
			_service = service;
		}

		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			return "value";
		}

		[HttpGet]
		public async Task<IActionResult> Get(string restaurant)
		{
			var view = await _service.GetYaposhkaSets(restaurant);
			return Ok(view);
		}

	}
}
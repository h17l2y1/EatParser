using System.Threading.Tasks;
using EatParser.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EatParser.Api.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class SushiController : ControllerBase
	{
		private readonly ISushiService _service;

		public SushiController(ISushiService service)
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
			var view = await _service.GetMafiaSets(restaurant);
			return Ok(view);
		}


	}
}
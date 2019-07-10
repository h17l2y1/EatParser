
using System.Threading.Tasks;
using EatParser.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EatParser.Api.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		private readonly ITestService _service;

		public TestController(ITestService service)
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
			var view = await _service.Get(restaurant);
			return Ok(view);
		}

	}
}
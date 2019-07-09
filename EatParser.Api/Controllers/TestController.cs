
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EatParser.Api.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		private readonly IService _service;

		public TestController(IService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> StartGame(string prop1, string prop2)
		{
			var view = await _service.Start(prop1, prop2);
			return Ok(view);
		}
	}
}
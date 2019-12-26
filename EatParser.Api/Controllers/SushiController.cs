using EatParser.Services.Services.Interfaces;
using EatParser.ViewModels.Sushi;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			GetAllSushiView view = await _service.GetAllSetsAsync();
			return Ok(view);
		}
	}
}
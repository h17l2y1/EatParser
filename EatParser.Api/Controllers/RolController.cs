using System.Threading.Tasks;
using EatParser.Services.Services.Interfaces;
using EatParser.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EatParser.Api.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class RolController : ControllerBase
	{
		private readonly IRolSetService _service;

		public RolController(IRolSetService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			RolSetView view = await _service.GetAllSetsAsync();
			return Ok(view);
		}

		[HttpGet]
		public async Task<IActionResult> GetYaposhka()
		{
			RolSetView view = await _service.GetYaposhkaSets();
			return Ok(view);
		}

		[HttpGet]
		public async Task<IActionResult> GetMafia()
		{
			RolSetView view = await _service.GetMafiaSets();
			return Ok(view);
		}

	}
}
using EatParser.Services.Services.Interfaces;
using EatParser.ViewModels.Set;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EatParser.Api.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class SetController : ControllerBase
	{
		private readonly ISetService _service;

		public SetController(ISetService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			GetAllSetView view = await _service.GetAllSetsAsync();
			return Ok(view);
		}

	}
}
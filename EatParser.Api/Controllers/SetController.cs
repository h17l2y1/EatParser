using System.Threading.Tasks;
using EatParser.Services.Services.Interfaces;
using EatParser.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
			GetAllRolView view = await _service.GetAllSetsAsync();
			return Ok(view);
		}

	}
}
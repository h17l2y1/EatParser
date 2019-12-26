using EatParser.Services.Services.Interfaces;
using EatParser.ViewModels.Pizza;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EatParser.Api.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class PizzaController : ControllerBase
	{
		private readonly IPizzaService _service;

		public PizzaController(IPizzaService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			GetAllPizzaView view = await _service.GetAllSetsAsync();
			return Ok(view);
		}
	}
}
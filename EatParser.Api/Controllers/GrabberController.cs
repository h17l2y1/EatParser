using EatParser.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EatParser.Api.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class GrabberController : ControllerBase
	{
		private readonly IGrabberService _service;

		public GrabberController(IGrabberService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GrabbAll()
		{
			await _service.GrabbAllRestaurant();
			return Ok();
		}

		[HttpGet]
		public async Task<IActionResult> GrabbYaposhka()
		{
			await _service.GrabbYaposhka();
			return Ok();
		}

		[HttpGet]
		public async Task<IActionResult> GrabbMafia()
		{
			await _service.GrabbMafia();
			return Ok();
		}

		[HttpGet]
		public async Task<IActionResult> GrabbSushiPapa()
		{
			await _service.GrabbSushiPapa();
			return Ok();
		}

		[HttpGet]
		public async Task<IActionResult> GrabbRollClub()
		{
			await _service.GrabbRollClub();
			return Ok();
		}

	}

}
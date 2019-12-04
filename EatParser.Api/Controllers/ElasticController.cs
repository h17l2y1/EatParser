using EatParser.Entities.Entities;
using EatParser.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Api.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ElasticController : ControllerBase
	{
		private readonly IEsService _service;

		public ElasticController(IEsService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> Search(string name)
		{
			IReadOnlyCollection<Person> response = await _service.Search(name);
			return Ok(response);
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			IndexResponse response = await _service.Index();
			return Ok(response);
		}

		[HttpGet]
		public async Task<IActionResult> IndexMany()
		{
			BulkResponse response = await _service.IndexMany();
			return Ok(response);
		}
	}
}
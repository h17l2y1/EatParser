using EatParser.Entities.Entities;
using EatParser.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System.Collections.Generic;
using System.Reflection.Metadata;
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
		// api/Elastic/Search?name=Ronaldo
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

		[HttpGet]
		public async Task<IActionResult> IndexFile()
		{
			IndexResponse response = await _service.IndexFile();
			return Ok(response);
		}

		[HttpGet]
		public async Task<IActionResult> SearchFile(string word)
		{
			var response = await _service.SearchInFile(word);
			return Ok(response);
		}

	}
}
using EatParser.Entities.Entities;
using EatParser.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Api.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ElasticController : ControllerBase
	{
		private readonly IElasticService _service;

		public ElasticController(IElasticService service)
		{
			_service = service;
		}

		[HttpGet]
		// api/Elastic/Search?name=Ronaldo
		public async Task<IActionResult> Search(string name)
		{
			var response = await _service.Search(name);
			return Ok(response);
		}
		
		[HttpGet]
		public async Task<IActionResult> IndexMany()
		{
			var personList = new List<Person>
			{
				new Person { Id = 2, FirstName = "Ronaldo", LastName = "Cristiano" },
				new Person { Id = 3, FirstName = "David", LastName = "Beckham" },
				new Person { Id = 4, FirstName = "Leonel", LastName = "Messi" }
			};

			var response = await _service.IndexMany(personList);
			return Ok(response);
		}

		[HttpGet]
		public async Task<IActionResult> IndexOne()
		{
			var person = new Person { Id = 4, FirstName = "Leonel", LastName = "Messi" };
			var response = await _service.IndexOne(person);
			return Ok(response);
		}
	}
}
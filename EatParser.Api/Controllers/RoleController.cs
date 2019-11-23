﻿using System.Threading.Tasks;
using EatParser.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EatParser.Api.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class RoleController : ControllerBase
	{
		private readonly IGrabberService _service;

		public RoleController(IGrabberService service)
		{
			_service = service;
		}

		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			return "value";
		}

		[HttpGet]
		public async Task<IActionResult> GetByRestaurant(string restaurant)
		{
			await _service.GetMafiaSets();
			return Ok();
		}

		[HttpGet]
		public ActionResult<string> GetAll()
		{
			return "value";
		}

	}
}
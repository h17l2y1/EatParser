﻿using EatParser.Services.Services.Interfaces;
using EatParser.ViewModels.Rol;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EatParser.Api.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class RolController : ControllerBase
	{
		private readonly IRolService _service;

		public RolController(IRolService service)
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
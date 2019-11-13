using EatParser.Services.Services.Interfaces;
using EatParser.ViewModels.Account.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EatParser.Api.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IAccountService _accountService;

		public AccountController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		[HttpPost]
		public async Task<IActionResult> SignUp([FromBody]SignUpAccountView view)
		{
			await _accountService.SignUpAsync(view);

			return Ok();
		}
	}
}
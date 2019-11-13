using AutoMapper;
using EatParser.Entities.Entities;
using EatParser.Services.Services.Interfaces;
using EatParser.ViewModels.Account.Request;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EatParser.Services.Services
{
	public class AccountService : IAccountService
	{
		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;

		public AccountService(UserManager<User> userManager, IMapper mapper)
		{
			_mapper = mapper;
			_userManager = userManager;
		}

		public async Task SignUpAsync(SignUpAccountView view)
		{

			User user = _mapper.Map<SignUpAccountView, User>(view);

			IdentityResult result = await _userManager.CreateAsync(user);

		}

	}
}

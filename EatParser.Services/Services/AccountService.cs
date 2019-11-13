using AutoMapper;
using EatParser.Entities.Entities;
using EatParser.Services.Providers.Interfaces;
using EatParser.Services.Services.Interfaces;
using EatParser.ViewModels.Account.Request;
using EatParser.ViewModels.Account.Response;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EatParser.Services.Services
{
	public class AccountService : IAccountService
	{
		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;
		private readonly IJwtProvider _jwtProvider;

		public AccountService(UserManager<User> userManager, IMapper mapper, IJwtProvider jwtProvider)
		{
			_mapper = mapper;
			_userManager = userManager;
			_jwtProvider = jwtProvider;
		}

		public async Task SignUp(SignUpAccountView view)
		{
			User user = _mapper.Map<SignUpAccountView, User>(view);
			IdentityResult result = await _userManager.CreateAsync(user);

		}
		

		public async Task<JwtView> Login(LoginAccountView view)
		{
			User user = _mapper.Map<LoginAccountView, User>(view);
			var token = _jwtProvider.CreateToken(user);





			return null;
		}

	}
}

using EatParser.Entities.Entities;
using EatParser.ViewModels.Account.Response;

namespace EatParser.Services.Providers.Interfaces
{
	public interface IJwtProvider
	{
		JwtView CreateToken(User user);
	}
}

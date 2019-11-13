using EatParser.ViewModels.Account.Request;
using EatParser.ViewModels.Account.Response;
using System.Threading.Tasks;

namespace EatParser.Services.Services.Interfaces
{
	public interface IAccountService
	{
		Task SignUp(SignUpAccountView view);

		Task<JwtView> Login(LoginAccountView view);
	}
}

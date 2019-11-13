
namespace EatParser.ViewModels.Account.Response
{
	public class JwtView
	{
		public string AccessToken { get; set; }
		public string RefreshToken { get; set; }
		public string UserRole { get; set; }
		public string UserName { get; set; }
	}
}

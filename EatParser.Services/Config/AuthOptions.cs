using System;

namespace EatParser.Services.Config
{
	public class AuthOptions
	{
		public string Issuer { get; set; }
		public string Audience { get; set; }
		public string Key { get; set; }
		public int LifeTime { get; set; }

		public int JwtExpireMinutes { get; set; }
		public TimeSpan AccessTokenExpiration { get; set; } = TimeSpan.FromDays(7);
		public TimeSpan RefreshTokenExpiration { get; set; } = TimeSpan.FromDays(60);
	}
}

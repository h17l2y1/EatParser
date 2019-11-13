using EatParser.Entities.Entities;
using EatParser.Services.Config;
using EatParser.Services.Providers.Interfaces;
using EatParser.ViewModels.Account.Response;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EatParser.Services.Providers
{
	public class JwtProvider : IJwtProvider
	{
		private readonly AuthOptions _authOptions;

		public JwtProvider(IOptions<AuthOptions> authOptions)
		{
			_authOptions = authOptions.Value;
		}

		public JwtView CreateToken(User user)
		{
			var now = DateTime.Now;
			var accessClaims = new List<Claim>
			{
				new Claim("Id", user.Id.ToString()),
				new Claim("UserName", user.UserName),
				new Claim("Password", user.Password),
			};

			var refreshClaims = new List<Claim>
			{
				new Claim("Id", user.Id.ToString()),
				new Claim("UserName", user.UserName)
			};

			var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_authOptions.Key));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var accessExpires = now.Add(_authOptions.AccessTokenExpiration);
			var accessToken = GenerateToken(_authOptions.Issuer, null, accessExpires, accessClaims, creds);
			var encodedAccess = new JwtSecurityTokenHandler().WriteToken(accessToken);

			var refreshExpires = now.Add(_authOptions.RefreshTokenExpiration);
			var refreshToken = GenerateToken(_authOptions.Issuer, null, refreshExpires, refreshClaims, creds);
			var encodedRefresh = new JwtSecurityTokenHandler().WriteToken(refreshToken);

			return new JwtView()
			{
				AccessToken = encodedAccess,
				RefreshToken = encodedRefresh,
				UserRole = "User",
				UserName = user.UserName,
			};
		}

		private static JwtSecurityToken GenerateToken(string issuer, string audience, DateTime expiration, List<Claim> claims, SigningCredentials creds)
		{
			return new JwtSecurityToken(
				issuer: issuer,
				audience: audience,
				claims: claims,
				expires: expiration,
				signingCredentials: creds);
		}




	}
}

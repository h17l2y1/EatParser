﻿using EatParser.Services.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatParser.Api.Extension
{
	public class AuthenticationExtension
	{
		public static void InjectAuthentication(IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<AuthOptions>(configuration.GetSection("AuthOptions"));


			//IConfigurationSection authTokenProviderOptions = configuration.GetSection(nameof(AuthOptions));
			//var jetKey = authTokenProviderOptions["Key"];
			//var key = Encoding.ASCII.GetBytes(jetKey);

			//services.AddAuthentication(x =>
			//{
			//	x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			//	x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			//})
		 //  .AddJwtBearer(x =>
		 //  {
			//   x.RequireHttpsMetadata = false;
			//   x.SaveToken = true;
			//   x.TokenValidationParameters = new TokenValidationParameters
			//   {
			//	   ValidateIssuerSigningKey = true,
			//	   IssuerSigningKey = new SymmetricSecurityKey(key),
			//	   ValidateIssuer = false,
			//	   ValidateAudience = false
			//   };
		 //  });
		}
	}
}

using EatParser.DataAccess.Config;
using EatParser.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using EatParser.Services.Services.Interfaces;
using EatParser.Services.Providers;
using EatParser.Services.Providers.Interfaces;
using EatParser.Services.Helpers.Interfaces;
using EatParser.Services.Helpers;

namespace EatParser.Services.Config
{
	public static class ConfigureBusinessLogic
	{
		public static void InjectBusinessLogicDependency(this IServiceCollection services, IConfiguration сonfiguration)
		{
			//Automapper setup
			var config = new AutoMapper.MapperConfiguration(c =>
			{
				c.AddProfile(new MapperProfile());
			});
			var mapper = config.CreateMapper();
			services.AddSingleton(mapper);

			services.AddSingleton<IEsClientProvider, EsClientProvider>();


			services.InjectDataAccessDependency(сonfiguration);


			// Services;
			services.AddScoped<IGrabberService, GrabberService>();
			services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<IRolSetService, RolSetService>();
			services.AddScoped<IEsService, EsService>();

			// Providers;
			services.AddScoped<IYaposhkaProvider, YaposhkaProvider>();
			services.AddScoped<IMafiaProvider, MafiaProvider>();
			services.AddScoped<IJwtProvider, JwtProvider>();

			// Helpers;
			services.AddScoped<IHtmlLoaderHelper, HtmlLoaderHelper>();
			services.AddScoped<IYaposhkaHelper, YaposhkaHelper>();
			services.AddScoped<IMafiaHelper , MafiaHelper>();

		}

	}
}

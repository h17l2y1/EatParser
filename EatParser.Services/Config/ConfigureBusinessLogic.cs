using EatParser.DataAccess.Config;
using EatParser.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using EatParser.Services.Services.Interfaces;
using EatParser.Services.Providers;
using EatParser.Services.Providers.Interfaces;
using EatParser.Services.Helpers.Interfaces;
using EatParser.Services.Helpers;
using AutoMapper;

namespace EatParser.Services.Config
{
	public static class ConfigureBusinessLogic
	{
		public static void InjectBusinessLogicDependency(this IServiceCollection services, IConfiguration сonfiguration)
		{
			AddAutoMapper(services);
			AddDependecies(services);

			services.InjectDataAccessDependency(сonfiguration);
		}

		private static void AddAutoMapper(IServiceCollection services)
		{
			var config = new MapperConfiguration(c =>
			{
				c.AddProfile(new MapperProfile());
			});

			IMapper mapper = config.CreateMapper();

			services.AddSingleton(mapper);
		}

		private static void AddDependecies(IServiceCollection services)
		{
			// Services;
			services.AddScoped<IGrabberService, GrabberService>();
			services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<IRolService, RolService>();
			services.AddScoped<ISetService, SetService>();
			services.AddScoped<ISushiService, SushiService>();
			services.AddScoped<IPizzaService, PizzaService>();

			// Providers;
			services.AddScoped<IJwtProvider, JwtProvider>();
			services.AddScoped<IYaposhkaProvider, YaposhkaProvider>();
			services.AddScoped<IMafiaProvider, MafiaProvider>();
			services.AddScoped<ISushiPapaProvider, SushiPapaProvider>();
			services.AddScoped<IRollClubProvider, RollClubProvider>();

			// Helpers;
			services.AddScoped<IHtmlLoaderHelper, HtmlLoaderHelper>();
			services.AddScoped<IYaposhkaHelper, YaposhkaHelper>();
			services.AddScoped<IMafiaHelper, MafiaHelper>();
			services.AddScoped<ISushiPapaHelper, SushiPapaHelper>();
			services.AddScoped<IRollClubHelper, RollClubHelper>();
		}

	}
}

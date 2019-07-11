using EatParser.DataAccess.Config;
using EatParser.Services.Interfaces;
using EatParser.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Parser.Core;
using Parser.Core.Habra;
using EatParser.Services.Core.Intefraces;

namespace EatParser.Services.Config
{
	public static class ConfigureBusinessLogic
	{
		public static void InjectBusinessLogicDependency(this IServiceCollection services, IConfiguration сonfiguration)
		{
			// Automapper setup
			//var config = new AutoMapper.MapperConfiguration(c =>
			//{
			//	c.AddProfile(new EntityViewProfile());
			//});
			//var mapper = config.CreateMapper();
			//services.AddSingleton(mapper);

			services.InjectDataAccessDependency(сonfiguration);


			// <Interface, Service>();
			services.AddScoped<ITestService, TestService>();
			services.AddScoped<IHabraParser, HabraParser>();
			services.AddScoped<IParserWorker, ParserWorker>();

		}

	}



}

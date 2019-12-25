using EatParser.Services.Config;
using EatParser.DataAccess.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EatParser.Api.Extension
{
	public static class ConfigureExtension
	{
		public static void InjectExtension(this IServiceCollection services, IConfiguration сonfiguration)
		{


			ElasticSearchExtension.InjectElasticSearch(services, сonfiguration);
			AuthenticationExtension.InjectAuthentication(services, сonfiguration);
			CorsExtension.InjectCors(services);


			//services.InjectBusinessLogicDependency(сonfiguration);

			services.InjectDataAccessDependency(сonfiguration);

			//services.InjectAutoMapper();


			//services.InjectAuthentication(сonfiguration);

			//services.InjectElasticSearch(сonfiguration);

			//services.InjectCors(сonfiguration);


		}
	}
}

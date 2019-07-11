using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EatParser.DataAccess.Config
{
	public static class ConfigureDataAccess
	{
		public static void InjectDataAccessDependency(this IServiceCollection services, IConfiguration сonfiguration)
		{
			// Setup dynamic ORM
			//string orm = сonfiguration.GetSection("ORM").Value;
			//if (orm == ORMType.EntityFramework.ToString())
			//{
			//	services.AddDbContext<ApplicationContext>(options => options
			//		.UseSqlServer(сonfiguration.GetSection("ConnectionStrings:SqlServer").Value));
			//}

			//services.AddScoped<Interface, Repository>();
			


		}
	}
}

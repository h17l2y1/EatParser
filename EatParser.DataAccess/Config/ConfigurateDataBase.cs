using EatParser.DataAccess.Repositories;
using EatParser.DataAccess.Repositories.Interfaces;
using EatParser.Entities.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EatParser.DataAccess.Config
{
	public static class ConfigureDataAccess
	{
		public static void InjectDataAccessDependency(this IServiceCollection services, IConfiguration configuration)
		{

			services.AddIdentity<User, UserRole>().AddEntityFrameworkStores<ApplicationContext>();

			services.Configure<ConnectionStrings>(x => configuration.GetSection("ConnectionStrings").Bind(x));

			// Dapper Repository
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<IRoleSetRepository, RoleSetRepository>();

		}
	}
}

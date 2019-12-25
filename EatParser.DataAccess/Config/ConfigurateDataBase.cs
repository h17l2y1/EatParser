using EatParser.DataAccess.Repositories;
using EatParser.DataAccess.Repositories.Interfaces;
using EatParser.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EatParser.DataAccess.Config
{
	public static class ConfigureDataAccess
	{
		public static void InjectDataAccessDependency(this IServiceCollection services, IConfiguration configuration)
		{
			// hard code
			string section = "ConnectionStringsHome:DefaultConnection";

			services.AddIdentity<User, UserRole>().AddEntityFrameworkStores<ApplicationContext>();

			services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetSection(section).Value));

			services.Configure<ConnectionStrings>(x => configuration.GetSection("ConnectionStringsHome").Bind(x));


			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<IRolSetRepository, RolSetRepository>();

		}
	}
}

using EatParser.DataAccess.Repositories;
using EatParser.DataAccess.Repositories.Interfaces;
using EatParser.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EatParser.DataAccess.Config
{
	public static class ConfigureDataAccess
	{
		public static void InjectDataAccessDependency(this IServiceCollection services, IConfiguration configuration)
		{

			services.AddIdentity<User, UserRole>().AddEntityFrameworkStores<ApplicationContext>();


			services.AddDbContext<ApplicationContext>(options => 
				options.UseSqlServer(configuration.GetSection("ConnectionStrings:DefaultConnection").Value));

			//services.AddDbContext<ApplicationContext>(options =>
			//	options.UseSqlServer(configuration.GetConnectionString(ApplicationConstants.CONNECTION_STRING_NAME)));

			// EF6
			//services.AddScoped<Interface, Repository>();


			// Dapper
			//services.AddTransient<Interface, Repository>();
			services.AddTransient<IUserRepository, UserRepository>();



		}
	}
}

using EatParser.DataAccess.Repositories;
using EatParser.DataAccess.Repositories.Interfaces;
using EatParser.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EatParser.DataAccess.Config
{
	public static class ConfigureDataAccess
	{
		public static void InjectDataAccessDependency(this IServiceCollection services, IConfiguration configuration)
		{
			AddDbContext(services, configuration);
			AddIdentity(services);
			Initialize(services);
			AddDependecies(services);
		}

		private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
		{
			string migrationsAssembly = typeof(ConfigureDataAccess).GetTypeInfo().Assembly.GetName().Name;
			string connectionString = configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<ApplicationContext>(options =>
			{
				options.UseSqlServer(connectionString, x => x.MigrationsAssembly(migrationsAssembly));
			}, ServiceLifetime.Scoped);

			services.Configure<ConnectionStrings>(x => configuration.GetSection("ConnectionStrings").Bind(x));
		}

		private static void AddIdentity(IServiceCollection services)
		{
			services.AddIdentity<User, UserRole>()
				.AddEntityFrameworkStores<ApplicationContext>()
				.AddDefaultTokenProviders();
		}

		private static void Initialize(IServiceCollection services)
		{
			ServiceProvider serviceProvider = services.BuildServiceProvider();

			using (var context = serviceProvider.GetRequiredService<ApplicationContext>())
			{
				if ((context.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
				{
					Initializer.SeedData(services);
				}
			}
		}

		public static void AddDependecies(IServiceCollection services)
		{
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<IRolRepository, RolRepository>();
			services.AddTransient<ISetRepository, SetRepository>();
			services.AddTransient<ISushiRepository, SushiRepository>();
			services.AddTransient<IPizzaRepository, PizzaRepository>();
			services.AddTransient<IRestaurantRepository, RestaurantRepository>();
		}

	}
}

using EatParser.Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EatParser.DataAccess.Config
{
	public class ApplicationContext : IdentityDbContext<User, UserRole, string>
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
			Database.Migrate();
		}

		public string DefaultConnection { get; set; }

		public DbSet<Set> Sets { get; set; }

		public DbSet<Rol> Rols { get; set; }

		public DbSet<Sushi> Sushis { get; set; }

		public DbSet<Pizza> Pizzas { get; set; }

		public DbSet<Restaurant> Restaurants { get; set; }

		//protected override void OnModelCreating(ModelBuilder builder)
		//{
		//	var init = new AutoComplete();

		//	var list = init.CreateRestaurant().ToArray();

		//	builder.Entity<Restaurant>().HasData(list);

		//	base.OnModelCreating(builder);
		//}
	}

}

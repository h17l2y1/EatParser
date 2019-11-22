using EatParser.Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EatParser.DataAccess.Config
{
	public class ApplicationContext : IdentityDbContext<User, UserRole, int>
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
			Database.Migrate();
		}

		public string DefaultConnection { get; set; }

		public DbSet<RolSet> RolSets { get; set; }

		public DbSet<Restaurant> Restaurants { get; set; }

		//protected override void OnModelCreating(ModelBuilder builder)
		//{
		//	var init = new AutoComplete();

		//	builder.Entity<Restaurant>().HasData(init.CreateRestaurant().ToArray());

		//	base.OnModelCreating(builder);
		//}
	}

}

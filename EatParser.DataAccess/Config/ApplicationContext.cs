using EatParser.Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EatParser.DataAccess.Config
{
	public class ApplicationContext : IdentityDbContext<User, UserRole, int>
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
		}

		public string DefaultConnection { get; set; }

		public DbSet<SushiSet> SushiSets { get; set; }


	}

}

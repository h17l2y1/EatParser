﻿using EatParser.Entities.Entities;
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

		public DbSet<Set> Sets { get; set; }

		public DbSet<Rol> Rols { get; set; }

		public DbSet<Sushi> Sushis { get; set; }

		public DbSet<Pizza> Pizzas { get; set; }

		public DbSet<Restaurant> Restaurants { get; set; }
	}

}

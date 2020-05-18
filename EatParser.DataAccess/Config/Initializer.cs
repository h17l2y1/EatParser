using EatParser.Entities.Entities;
using EatParser.Entities.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatParser.DataAccess.Config
{
    public static class Initializer
    {
        public static void SeedData(IServiceCollection services)
        {
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            //UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            //RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            //SeedRoles(roleManager).Wait();
            //SeedUsers(userManager).Wait();
            SeedRestaurants(serviceProvider).Wait();
        }

        private static async Task SeedRestaurants(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationContext>();

            if (!context.Restaurants.Any())
            {
                List<Restaurant> restaurantList = new List<Restaurant>()
                {
                    new Restaurant() { Name = RestaurantType.Mafia.ToString(), Id = "e852dc88-be1c-4c75-829b-087b492c3e35" },
                    new Restaurant() { Name = RestaurantType.Yaposhka.ToString(), Id = "461881d3-a45d-48a8-b70f-2c6bbedc9d69" },
                    new Restaurant() { Name = RestaurantType.SushiPapa.ToString(), Id = "097d5c06-dcae-4fb0-b7c5-5bee485ae601" },
                    new Restaurant() { Name = RestaurantType.RollClub.ToString(), Id = "c27bfca8-afb6-4e89-aca4-3cefb2ac0307" },
                };

                await context.AddRangeAsync(restaurantList);
                await context.SaveChangesAsync();
            }
        }

    }
}

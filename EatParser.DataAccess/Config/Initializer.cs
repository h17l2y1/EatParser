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
            SeedRegions(serviceProvider).Wait();
        }

        private static async Task SeedRegions(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationContext>();

            if (!context.Restaurants.Any())
            {
                List<Restaurant> restaurantList = new List<Restaurant>();

                foreach (RestaurantType type in Enum.GetValues(typeof(RestaurantType)))
                {
                    restaurantList.Add(new Restaurant() { Name = type.ToString() });
                }
                try
                {
                    await context.AddRangeAsync(restaurantList);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                    throw;
                }


            }
        }

    }
}

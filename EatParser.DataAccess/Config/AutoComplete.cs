using EatParser.Entities.Entities;
using EatParser.Entities.Types;
using System.Collections.Generic;

namespace EatParser.DataAccess.Config
{
	public class AutoComplete
	{
		public List<Restaurant> CreateRestaurant()
		{
			var list = new List<Restaurant>()
			{
				new Restaurant() { Id = (int)RestaurantType.Mafia, Name = RestaurantType.Mafia.ToString() },
				new Restaurant() { Id = (int)RestaurantType.Yaposhka, Name = RestaurantType.Yaposhka.ToString() }
			};

			return list;
		}
	}
}

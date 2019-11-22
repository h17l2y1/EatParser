using EatParser.Entities.Entities;
using System.Collections.Generic;

namespace EatParser.DataAccess.Config
{
	public class AutoComplete
	{
		public List<Restaurant> CreateRestaurant()
		{
			var list = new List<Restaurant>()
			{
				new Restaurant() { Name = "Mafia" },
				new Restaurant() { Name = "Yaposhka" }
			};

			return list;
		}
	}
}

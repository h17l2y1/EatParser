using EatParser.Entities.Entities;
using EatParser.Entities.Types;
using System;
using System.Collections.Generic;

namespace EatParser.DataAccess.Config
{
	public class AutoComplete
	{
		public List<Restaurant> CreateRestaurant()
		{
			var list = new List<Restaurant>();

			foreach (RestaurantType type in Enum.GetValues(typeof(RestaurantType)))
			{
				list.Add(new Restaurant() { Id = (int)type, Name = type.ToString() });
			}

			return list;
		}
	}
}

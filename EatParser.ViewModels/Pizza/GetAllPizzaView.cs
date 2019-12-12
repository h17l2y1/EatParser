using System.Collections.Generic;

namespace EatParser.ViewModels.Pizza
{
	public class GetAllPizzaView
	{
		public List<GetAllPizzaViewItem> Pizzas { get; set; }

		public GetAllPizzaView(List<GetAllPizzaViewItem> set)
		{
			Pizzas = set;
		}

	}

	public class GetAllPizzaViewItem : ProductView
	{

	}
}

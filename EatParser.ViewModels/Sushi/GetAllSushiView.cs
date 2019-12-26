using System.Collections.Generic;

namespace EatParser.ViewModels.Sushi
{
	public class GetAllSushiView
	{
		public List<GetAllSushiViewItem> Sushi { get; set; }

		public GetAllSushiView(List<GetAllSushiViewItem> set)
		{
			Sushi = set;
		}

	}

	public class GetAllSushiViewItem : ProductView
	{

	}
}

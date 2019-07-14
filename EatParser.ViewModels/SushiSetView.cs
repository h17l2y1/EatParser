using System.Collections.Generic;

namespace EatParser.ViewModels
{
	public class SushiSetView
	{
		public List<SetView> SushiSet { get; set; }

		public SushiSetView(List<SetView> set)
		{
			SushiSet = set;
		}

	}
}

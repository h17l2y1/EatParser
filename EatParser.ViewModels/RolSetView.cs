using System.Collections.Generic;

namespace EatParser.ViewModels
{
	public class RolSetView
	{
		public List<SetView> RolSet { get; set; }

		public RolSetView(List<SetView> set)
		{
			RolSet = set;
		}

	}
}

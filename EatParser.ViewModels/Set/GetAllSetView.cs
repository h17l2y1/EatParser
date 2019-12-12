using System.Collections.Generic;

namespace EatParser.ViewModels.Set
{
	public class GetAllSetView
	{
		public List<GetAllSetViewItem> Sets { get; set; }

		public GetAllSetView(List<GetAllSetViewItem> set)
		{
			Sets = set;
		}

	}

	public class GetAllSetViewItem : ProductView
	{

	}
}

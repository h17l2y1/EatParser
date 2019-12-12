using System.Collections.Generic;

namespace EatParser.ViewModels
{
	public class GetAllRolView
	{
		public List<ProductView> Rols { get; set; }

		public GetAllRolView(List<ProductView> set)
		{
			Rols = set;
		}

	}
}

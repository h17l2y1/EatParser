using System.Collections.Generic;

namespace EatParser.ViewModels.Rol
{
	public class GetAllRolView
	{
		public List<GetAllRolViewItem> Rols { get; set; }

		public GetAllRolView(List<GetAllRolViewItem> set)
		{
			Rols = set;
		}

	}

	public class GetAllRolViewItem : ProductView
	{

	}
}

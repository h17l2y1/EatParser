using System.Collections.Generic;
using System.Linq;
using AngleSharp.Html.Dom;

namespace Parser.Core.Habra
{
    public class HabraParser : IHabraParser
	{
		public List<string> Parse(IHtmlDocument document)
		{
			var list = new List<string>();
			var items = document.QuerySelectorAll("a")
				.Where(item => item.ClassName != null && item.ClassName.Contains("post__title_link"));

			foreach (var item in items)
			{
				list.Add(item.TextContent);
			}

			return list;
		}
	}
}

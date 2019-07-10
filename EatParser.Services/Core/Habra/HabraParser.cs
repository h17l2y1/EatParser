using System.Collections.Generic;
using System.Linq;
using AngleSharp.Html.Dom;

namespace Parser.Core.Habra
{
    class HabraParser : IParser<string[]>
    {
		public string[] Parse(IHtmlDocument document)
		{
			var list = new List<string>();
			var items = document.QuerySelectorAll("a")
				.Where(item => item.ClassName != null && item.ClassName.Contains("post__title_link"));

			foreach (var item in items)
			{
				list.Add(item.TextContent);
			}

			var a = list.ToArray();
			return a;
		}
	}
}

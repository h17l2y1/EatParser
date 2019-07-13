using AngleSharp.Dom;
using EatParser.Entities.Entities;
using EatParser.Services.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EatParser.Services.Helpers
{
	public class YaposhkaHelper : IYaposhkaHelper
	{
		public List<string> Parse1(IDocument document)
		{
			var list = new List<string>();
			var items = document.QuerySelectorAll("a")
				.Where(item => item.ClassName != null && item.ClassName.Contains("brander-quickview product-name"));

			foreach (var item in items)
			{
				list.Add(item.TextContent.Trim());
			}

			return list;
		}

		public List<string> Waight(IDocument document)
		{
			var list = new List<string>();
			var items = document.QuerySelectorAll("div")
				.Where(item => item.ClassName != null && item.ClassName.Contains("weight-item"));

			foreach (var item in items)
			{
				list.Add(item.TextContent.Trim());
			}

			return list;
		}
		
		public List<string> Count(IDocument document)
		{
			var list = new List<string>();
			var items = document.QuerySelectorAll("div")
				.Where(item => item.ClassName != null && item.ClassName.Contains("listing-short-description"));

			foreach (var item in items)
			{
				list.Add(item.TextContent.Trim());
			}

			return list;
		}

		private int aaa(IElement elem)
		{
			string str = elem.TextContent.Trim();
			if (str.Length > 0)
			{
				return Int32.Parse(str.Substring(0, str.Length - 3));
			}
			return 0;
		}


		public List<string> Parse(IDocument document)
		{
			List<string> names = document.QuerySelectorAll("a")
				.Where(item => item.ClassName != null && item.ClassName.Contains("brander-quickview product-name"))
				.Select(i => i.TextContent.Trim())
				.ToList();

			List<int> weight = document.QuerySelectorAll("div")
				.Where(item => item.ClassName != null && item.ClassName.Contains("weight-item"))
				.Select(i => Int32.Parse(i.TextContent.Trim().Substring(0, i.TextContent.Trim().Length - 2)))
				.ToList();

			List<int> count = document.QuerySelectorAll("div")
				.Where(item => item.ClassName != null && item.ClassName.Contains("listing-short-description"))
				.Select(i => Int32.Parse(i.TextContent.Trim().Substring(0, i.TextContent.Trim().Length - 4)))
				.ToList();

			var priceX4 = document.QuerySelectorAll("span")
				.Where(item => item.ClassName != null && item.ClassName.Contains("price"))
				.Select(i => aaa(i))
				.ToList();

			var price = priceX4.Where((c, i) => (i + 1) % 4 == 0).ToList();

			//var image = document.QuerySelectorAll("img")
			//.Where(item => item.ClassName != null && item.ClassName.Contains("photo image lazy lazy-blur lazy-loaded"))
			//.Select(i => i.TextContent.Trim())
			//.Select(m => m.GetAttribute("src"))
			//.ToList();

			var sets = Enumerable
				.Range(0, names.Count)
				.Select(i => new SushiSet
				{
					Name = names[i],
					Weight = weight[i],
					Count = count[i],
					Price = price[i]
				})
				.ToList();

			return null;
		}





	}
}

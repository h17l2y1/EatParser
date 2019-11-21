using AngleSharp.Dom;
using EatParser.Entities.Entities;
using EatParser.Services.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EatParser.Services.Helpers
{
	public class YaposhkaHelper : IYaposhkaHelper
	{
		public List<RolSet> Parse(IDocument document)
		{
			List<string> names = GetNames(document);
			List<int> count = GetCount(document);
			List<int> weight = GetWeight(document);
			List<string> images = GetImages(document);
			List<int> prices = GetPrice(document);

			List<RolSet> sets = Enumerable
				.Range(0, names.Count)
				.Select(i => new RolSet
				{
					Name = names[i],
					Weight = weight[i],
					Count = count[i],
					Price = prices[i],
					Image = images[i]
				})
				.ToList();

			return sets;
		}

		private List<string> GetNames(IDocument document)
		{
			List<string> names = document.QuerySelectorAll("a")
				.Where(item => item.ClassName != null && item.ClassName.Contains("brander-quickview product-name"))
				.Select(i => i.TextContent.Trim())
				.ToList();

			return names;
		}

		private List<int> GetWeight(IDocument document)
		{
			List<int> weight = document.QuerySelectorAll("div")
				.Where(item => item.ClassName != null && item.ClassName.Contains("weight-item"))
				.Select(i => Int32.Parse(i.TextContent.Trim().Substring(0, i.TextContent.Trim().Length - 2)))
				.ToList();

			return weight;
		}

		private List<int> GetCount(IDocument document)
		{
			List<int> count = document.QuerySelectorAll("div")
				.Where(item => item.ClassName != null && item.ClassName.Contains("listing-short-description"))
				.Select(i => Int32.Parse(i.TextContent.Trim().Substring(0, i.TextContent.Trim().Length - 4)))
				.ToList();

			return count;
		}

		private List<string> GetImages(IDocument document)
		{
			List<string> images = document
				.QuerySelectorAll("img")
				.Where(item => item.ClassName == "photo image lazy lazy-loading lazy-blur")
				.Select(m => m.GetAttribute("src"))
				.ToList();

			return images;
		}

		private List<int> GetPrice(IDocument document)
		{
			var priceX4 = document.QuerySelectorAll("span")
				.Where(item => item.ClassName != null && item.ClassName.Contains("price"))
				.Select(i => PriceToInt(i))
				.ToList();

			var price = priceX4.Where((c, i) => (i + 1) % 4 == 0).ToList();

			return price;
		}

		private int PriceToInt(IElement elem)
		{
			string str = elem.TextContent.Trim();
			if (str.Length > 0)
			{
				return Int32.Parse(str.Substring(0, str.Length - 3));
			}
			return 0;
		}

	}
}

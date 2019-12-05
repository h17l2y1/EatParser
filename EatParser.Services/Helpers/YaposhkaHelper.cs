using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using EatParser.Entities.Entities;
using EatParser.Entities.Types;
using EatParser.Services.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EatParser.Services.Helpers
{
	public class YaposhkaHelper : IYaposhkaHelper
	{
		public List<RolSet> Parse(IDocument document)
		{
			IHtmlCollection<IElement> tdList = document.QuerySelectorAll("div.product-container");

			List<RolSet> sets = Enumerable
				.Range(0, tdList.Length)
				.Select(i => GetRolSet(tdList[i]))
				.ToList();

			return sets;
		}

		//private List<string> GetNames(IDocument document)
		//{
		//	List<string> names = document.QuerySelectorAll("a")
		//		.Where(item => item.ClassName != null && item.ClassName.Contains("brander-quickview product-name"))
		//		.Select(i => i.TextContent.Trim())
		//		.ToList();

		//	return names;
		//}

		//private List<int> GetWeight(IDocument document)
		//{
		//	List<int> weight = document.QuerySelectorAll("div")
		//		.Where(item => item.ClassName != null && item.ClassName.Contains("weight-item"))
		//		.Select(i => Int32.Parse(i.TextContent.Trim().Substring(0, i.TextContent.Trim().Length - 2)))
		//		.ToList();

		//	return weight;
		//}

		//private List<int> GetCount(IDocument document)
		//{
		//	List<int> count = document.QuerySelectorAll("div")
		//		.Where(item => item.ClassName != null && item.ClassName.Contains("listing-short-description"))
		//		.Select(i => Int32.Parse(i.TextContent.Trim().Substring(0, i.TextContent.Trim().Length - 4)))
		//		.ToList();

		//	return count;
		//}

		//private List<string> GetImages(IDocument document)
		//{
		//	List<string> images = document
		//		.QuerySelectorAll("img")
		//		.Where(item => item.ClassName == "photo image lazy lazy-loading lazy-blur")
		//		.Select(m => m.GetAttribute("src"))
		//		.ToList();

		//	return images;
		//}

		//private List<int> GetPrice(IDocument document)
		//{
		//	var priceX4 = document.QuerySelectorAll("span")
		//		.Where(item => item.ClassName != null && item.ClassName.Contains("price"))
		//		.Select(i => PriceToInt(i))
		//		.ToList();

		//	var price = priceX4.Where((c, i) => (i + 1) % 4 == 0).ToList();

		//	return price;
		//}

		//private int PriceToInt(IElement elem)
		//{
		//	string str = elem.TextContent.Trim();
		//	if (str.Length > 0)
		//	{
		//		return Int32.Parse(str.Substring(0, str.Length - 3));
		//	}
		//	return 0;
		//}

		private RolSet GetRolSet(IElement td)
		{
			var fullImage = GetData(td, "img.photo.image.lazy.lazy-loading.lazy-blur", "data-original");
			var cropImage = GetData(td, "source.photo.image.lazy.lazy-loading.lazy-blur", "data-original");
			var desc = GetData(td, "div.short-description");
			var count = GetData(td, "div.listing-short-description");
			var weight = GetData(td, "div.weight-item");
			var name = GetData(td, "div.name-wrap");
			var price = GetData(td, "span.price");

			var a1 = StringToInt(desc);
			var a2 = StringToInt(weight);
			var a3 = StringToInt(count);

			var newRolSet = new RolSet
			{
				Name = name,
				Weight = 1,
				Count = 2,
				Price = 3,
				Image = fullImage,
				RestaurantId = (int)RestaurantType.Yaposhka
			};

			return newRolSet;
		}

		private int StringToInt(string str)
		{
			str = Regex.Replace(str, "[^0-9.]", "");
			var number = Int32.Parse(str);
			return number;
		}

		private string GetData(IElement ielement, string selector)
		{
			IElement descDiv = ielement.QuerySelector(selector);
			string result = descDiv.Text();
			return result;
		}

		private string GetData(IElement ielement, string selector, string attribute)
		{
			IElement currentIelement = ielement.QuerySelector(selector);
			string result = currentIelement.GetAttribute(attribute);
			return result;
		}

	}
}

using AngleSharp.Dom;
using EatParser.Entities.Entities;
using EatParser.Entities.Types;
using EatParser.Services.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EatParser.Services.Helpers
{
	public class MafiaHelper : BaseHelper, IMafiaHelper
	{
		public List<T> Parse<T>(IDocument document) where T : Product
		{
			IHtmlCollection<IElement> iElementList = document.QuerySelectorAll("div.product-item");

			List<T> sets = Enumerable
				.Range(0, iElementList.Count())
				.Select(i => CreateProduct<T>(iElementList[i]))
				.ToList();

			return sets;
		}

		private T CreateProduct<T>(IElement td) where T : Product
		{
			IElement imgElement = td.QuerySelector("a.product-img");
			IElement nameElemnt = td.QuerySelector("div.product-title");

			string desc = GetData(td, "div.product-description");
			string priceStr = GetData(td, "div.price");
			string img = imgElement.Children.First().GetAttribute("src");
			string fullImg = $"https://mafia.ua{img}";
			string name = nameElemnt.Children.First().Text().Replace("\n", " ").Trim();
			string test = GetData(td, "div.product-weight");
			TempSet set = GetSetsData(test);

			int price = StringToInt(priceStr);

			T product = CreatObject<T>(name, desc, set.Weight, set.Count, price, fullImg, (int)RestaurantType.Mafia);

			return product;
		}

		private TempSet GetSetsData(string str)
		{
			string setString = Regex.Replace(str, @"[^0-9$.]", "").Trim();
			string[] setData = setString.Split(new char[] { '.' });

			var set = new TempSet();

			if (setData.Length < 2)
			{
				set.Weight = Int32.Parse(setData[0]);
			}
			if (setData.Length > 1)
			{
				set.Count = Int32.Parse(setData[0]);
				set.Weight = Int32.Parse(setData[1]);
			}

			return set;
		}

		private string GetData(IElement ielement, string selector)
		{
			IElement iElement = ielement.QuerySelector(selector);
			string result = iElement.Text();
			result = result.Replace("\n", " ").Trim();
			return result;
		}

		private class TempSet
		{
			public int? Count { get; set; }
			public int Weight { get; set; }
		}
	}


}

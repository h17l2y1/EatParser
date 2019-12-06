using AngleSharp.Dom;
using EatParser.Entities.Entities;
using EatParser.Entities.Types;
using EatParser.Services.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EatParser.Services.Helpers
{
	public class MafiaHelper : IMafiaHelper
	{
		public List<T> Parse<T>(IDocument document) where T : Product
		{
			IHtmlCollection<IElement> divs = document.QuerySelectorAll("div.product-item");

			List<T> sets = Enumerable
				.Range(0, divs.Count())
				.Select(i => GetRolSet<T>(divs[i]))
				.ToList();

			return sets;
		}

		private T GetRolSet<T>(IElement td) where T : Product
		{
			string desc = GetData(td, "div.product-description");
			string priceStr = GetData(td, "div.price");

			IElement currentIelement = td.QuerySelector("a.product-img");
			string img = currentIelement.Children.First().GetAttribute("src");
			string fullImg = $"https://mafia.ua{img}";

			IElement currentIelement2 = td.QuerySelector("div.product-title");
			string name = currentIelement2.Children.First().Text().Replace("\n", " ").Trim();

			string test = GetData(td, "div.product-weight");
			var set = GetSetsData(test);

			int price = StringToInt(priceStr);

			T genericObject = CreatObject<T>(name, desc, set.Weight, set.Count, price, fullImg, (int)RestaurantType.Mafia);

			return genericObject;
		}

		private T CreatObject<T>(string name, string desc, int weight, int? count, int price, string fullImg, int type) where T : Product
		{
			T genericObject = (T)Activator.CreateInstance(typeof(T));

			genericObject.Name = name;
			genericObject.Description = desc;
			genericObject.Weight = weight;
			genericObject.Count = count;
			genericObject.Price = price;
			genericObject.Image = fullImg;
			genericObject.RestaurantId = type;

			return genericObject;
		}

		private Set GetSetsData(string str)
		{
			string setString = Regex.Replace(str, @"[^0-9$.]", "").Trim();
			string[] setData = setString.Split(new char[] { '.' });

			var set = new Set();

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

		private int StringToInt(string str)
		{
			str = Regex.Replace(str, "[^0-9]", "");
			var number = Int32.Parse(str);
			return number;
		}

		private string GetData(IElement ielement, string selector)
		{
			IElement descDiv = ielement.QuerySelector(selector);
			string result = descDiv.Text();
			result = result.Replace("\n", " ").Trim();
			return result;
		}

	}

	public class Set
	{
		public int? Count { get; set; }
		public int Weight { get; set; }
	}
}

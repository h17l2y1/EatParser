using AngleSharp.Dom;
using EatParser.Entities.Entities;
using EatParser.Services.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EatParser.Services.Helpers
{
	public class MafiaHelper : IMafiaHelper
	{
		public List<SushiSet> Parse(IDocument document)
		{
			List<string> names = GetNames(document);
			Set set = GetСountWeightData(document);
			List<int> prices = GetPrice(document);
			List<string> images = GetImages(document);

			List<SushiSet> sets = Enumerable
				.Range(0, names.Count)
				.Select(i => new SushiSet
				{
					Name = names[i],
					Weight = set.Weight[i],
					Count = set.Count[i],
					Price = prices[i],
					Image = images[i]
				})
				.ToList();

			return sets;
		}

		private Set GetСountWeightData(IDocument document)
		{
			IEnumerable<IElement> setData = document.QuerySelectorAll("div")
				.Where(item => item.ClassName != null && item.ClassName.Contains("product-weight"));

			Set countWeightList = GetSetsData(setData);

			return countWeightList;

		}

		private Set GetSetsData(IEnumerable<IElement> elem)
		{
			var weigthList = new List<int>();
			var countList = new List<int>();

			foreach (var item in elem)
			{
				string setString = Regex.Replace(item.TextContent, @"[^0-9$.]", "").Trim();

				string[] setData = setString.Split(new char[] { '.' });

				if (setData.Length < 2)
				{
					countList.Add(0);
					weigthList.Add(Int32.Parse(setData[0]));
				}
				if (setData.Length > 1)
				{
					countList.Add(Int32.Parse(setData[0]));
					weigthList.Add(Int32.Parse(setData[1]));
				}
			}

			var set = new Set(countList, weigthList);

			return set;
		}

		private List<string> GetNames(IDocument document)
		{
			List<string> names = document.QuerySelectorAll("div")
				.Where(item => item.ClassName != null && item.ClassName.Contains("product-title"))
				.Select(i => i.Children.FirstOrDefault().TextContent.Trim())
				.ToList();

			return names;
		}

		private List<int> GetPrice(IDocument document)
		{
			List<int> prices = document.QuerySelectorAll("span")
				.Where(item => item.ClassName != null && item.ClassName.Contains("productPriceStatGA"))
				.Select(i => PriceToInt(i))
				.ToList();

			return prices;
		}

		private int PriceToInt(IElement elem)
		{
			string str = elem.TextContent.Trim();
			if (str.Length > 0)
			{
				return Int32.Parse(str);
			}
			return 0;
		}

		private List<string> GetImages(IDocument document)
		{
			var imageList = document
				.QuerySelectorAll("a")
				.Where(item => item.ClassName == "product-img")
				.Select(m => GetPath(m.Children.FirstOrDefault().OuterHtml))
				.ToList();

			return imageList;
		}

		private string GetPath(string outerHtmlString)
		{
			Regex regex = new Regex(@"\S*.jpeg");
			MatchCollection matchColl = regex.Matches(outerHtmlString);
			var path = matchColl[0].ToString().Remove(0, 6);
			var fullPath = $"https://mafia.ua/{path}";
			return fullPath;
		}

	}

	public class Set
	{

		public List<int> Count { get; set; }
		public List<int> Weight { get; set; }

		public Set(List<int> count, List<int> weight)
		{
			Count = count;
			Weight = weight;
		}

	}
}

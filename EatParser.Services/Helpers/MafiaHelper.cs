using AngleSharp.Dom;
using EatParser.Entities.Entities;
using EatParser.Services.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EatParser.Services.Helpers
{
	public class MafiaHelper : IMafiaHelper
	{
		public List<SushiSet> Parse(IDocument document)
		{

			List<string> names = GetNames(document);
			//List<int> count = GetCount(document);
			List<int> weight = GetWeight(document);
			//List<string> images = GetImages(document);
			//List<int> prices = GetPrice(document);

			List<SushiSet> sets = Enumerable
				.Range(0, names.Count)
				.Select(i => new SushiSet
				{
					Name = names[i],
					Weight = weight[i],
					//Count = count[i],
					//Price = prices[i],
					//Image = images[i]
				})
				.ToList();

			return null;
		}

		private List<int> GetWeight(IDocument document)
		{
			// "40 шт., 1005 г"s

			var weight = document.QuerySelectorAll("div")
				.Where(item => item.ClassName != null && item.ClassName.Contains("product-weight"))
				//.Select(i => Int32.Parse(i.TextContent.Trim().Substring(0, i.TextContent.Trim().Length - 2)))
				//.Select(i => test(i))
				//.Select(i => i.TextContent)
				.ToList();


			var weight2 = document.QuerySelectorAll("div")
				.Where(item => item.ClassName != null && item.ClassName.Contains("product-weight"));


			var a2 = test2(weight2);





			return null;

		}

		private List<string[]> test2(IEnumerable<IElement> elem)
		{
			var list = new List<string[]>();

			foreach (var item in elem)
			{
				var str = Regex.Replace(item.TextContent, @"[^0-9$.]", "").Trim();
				list.Add(str.Split(new char[] { '.' }));
			}

			return list;
		}


		private List<string> GetNames(IDocument document)
		{
			List<string> names = document.QuerySelectorAll("div")
				.Where(item => item.ClassName != null && item.ClassName.Contains("product-title"))
				.Select(i => i.Children.FirstOrDefault().TextContent.Trim())
				.ToList();

			return names;
		}

		//private List<string> GetImages(IDocument document)
		//{
		//	var images = document
		//		.QuerySelectorAll("a")
		//		.Where(item => item.ClassName == "product-img")
		//		//.Select(m => m.GetAttribute("src"))
		//		.ToList();

		//	return null;
		//}
	}
}

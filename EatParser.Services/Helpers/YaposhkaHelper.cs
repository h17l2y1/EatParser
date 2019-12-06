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
	public class YaposhkaHelper : IYaposhkaHelper
	{
		public List<Rol> Parse(IDocument document)
		{
			IHtmlCollection<IElement> tdList = document.QuerySelectorAll("div.product-container");

			List<Rol> sets = Enumerable
				.Range(0, tdList.Length)
				.Select(i => GetRolSet(tdList[i]))
				.ToList();

			return sets;
		}

		private Rol GetRolSet(IElement td)
		{
			string fullImage = GetData(td, "img.photo.image.lazy.lazy-loading.lazy-blur", "data-original");
			string cropImage = GetData(td, "source.photo.image.lazy.lazy-loading.lazy-blur", "data-original");
			string desc = GetData(td, "div.short-description");
			string name = GetData(td, "div.name-wrap");
			string priceStr = GetData(td, "span.price");
			string countStr = GetData(td, "div.listing-short-description");
			string weightStr = GetData(td, "div.weight-item");

			int price = StringToInt(priceStr);
			int count = StringToInt(countStr);
			int weight = StringToInt(weightStr);

			var newRolSet = new Rol
			{
				Name = name,
				Description = desc,
				Weight = weight,
				Count = count,
				Price = price,
				Image = fullImage,
				RestaurantId = (int)RestaurantType.Yaposhka
			};

			return newRolSet;
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

		private string GetData(IElement ielement, string selector, string attribute)
		{
			IElement currentIelement = ielement.QuerySelector(selector);
			string result = currentIelement.GetAttribute(attribute);
			result = result.Replace("\n", " ").Trim();
			return result;
		}

	}
}

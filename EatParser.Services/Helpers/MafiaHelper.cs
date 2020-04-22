using AngleSharp.Dom;
using EatParser.Entities.Entities;
using EatParser.Entities.Types;
using EatParser.Services.Helpers.Interfaces;
using EatParser.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace EatParser.Services.Helpers
{
	public class MafiaHelper : BaseHelper, IMafiaHelper
	{
		public IEnumerable<T> Parse<T>(IDocument document, string restaurantId) where T : Product
		{
			IHtmlCollection<IElement> iElementList = document.QuerySelectorAll("div.product-item");

			IEnumerable<T> products = Enumerable
				.Range(0, iElementList.Count())
				.Select(i => CreateProduct<T>(iElementList[i], restaurantId));

			return products;
		}

		private T CreateProduct<T>(IElement td, string restaurantId) where T : Product
		{
			IElement imgElement = td.QuerySelector("a.product-img");
			IElement nameElemnt = td.QuerySelector("div.product-title");

			string desc = GetData(td, "div.product-description");
			string priceStr = GetData(td, "div.price");
			string img = imgElement.Children.First().GetAttribute("src");
			string fullImg = $"https://mafia.ua{img}";
			string name = nameElemnt.Children.First().Text().Replace("\n", " ").Trim();

			string test = GetData(td, "div.product-weight");
			TempSet set = CreateTempSet(test);

			int? price = StringToInt(priceStr);
			string logo = GetLogoPath(RestaurantType.Mafia.ToString());

			T product = CreatProduct<T>(name, desc, set.Weight, set.Count, price, fullImg, restaurantId, logo);

			return product;
		}

	}
}

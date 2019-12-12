using AngleSharp.Dom;
using EatParser.Entities.Entities;
using EatParser.Entities.Types;
using EatParser.Services.Helpers.Interfaces;
using EatParser.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace EatParser.Services.Helpers
{
	public class SushiPapaHelper : BaseHelper, ISushiPapaHelper
	{
		public List<T> Parse<T>(IDocument document) where T : Product
		{
			IHtmlCollection<IElement> iElementList = document.QuerySelectorAll("div.card-inner");

			List<T> products = Enumerable
				.Range(0, iElementList.Count())
				.Select(i => CreateProduct<T>(iElementList[i]))
				.ToList();

			return products;
		}

		private T CreateProduct<T>(IElement td) where T : Product
		{
			string fullImage = GetData(td, "img.product-image", "src");
			string test = GetData(td, "div.product-introtext");
			TempSet set = CreateTempSet(test);
			string priceStr = GetData(td, "span.price");
			int? price = StringToInt(priceStr);
			string name = GetData(td, "img.product-image", "title");
			string desc = "";

			T product = CreatProduct<T>(name, desc, set.Weight, set.Count, price, fullImage, (int)RestaurantType.SushiPapa);

			return product;
		}

	}
}

using AngleSharp.Dom;
using EatParser.Entities.Entities;
using EatParser.Entities.Types;
using EatParser.Services.Helpers.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EatParser.Services.Helpers
{
	public class YaposhkaHelper : BaseHelper, IYaposhkaHelper
	{
		public List<T> Parse<T>(IDocument document) where T : Product
		{
			IHtmlCollection<IElement> iElementList = document.QuerySelectorAll("div.product-container");

			List<T> products = Enumerable
				.Range(0, iElementList.Count())
				.Select(i => CreateProduct<T>(iElementList[i]))
				.ToList();

			return products;
		}

		private T CreateProduct<T>(IElement td) where T : Product
		{
			string fullImage = GetData(td, "img.photo.image.lazy.lazy-loading.lazy-blur", "data-original");
			string cropImage = GetData(td, "source.photo.image.lazy.lazy-loading.lazy-blur", "data-original");
			string desc = GetData(td, "div.short-description");
			string name = GetData(td, "div.name-wrap");
			string priceStr = GetData(td, "span.price");
			string countStr = GetData(td, "div.listing-short-description");
			string weightStr = GetData(td, "div.weight-item");

			int price = StringToInt(priceStr);
			int count = countStr == null ? 0 : StringToInt(countStr); ;
			int weight = StringToInt(weightStr);

			T product = CreatObject<T>(name, desc, weight, count, price, fullImage, (int)RestaurantType.Yaposhka);

			return product;
		}

		private string GetData(IElement ielement, string selector)
		{
			IElement descDiv = ielement.QuerySelector(selector);
			if (descDiv == null)
			{
				return null;
			}

			string result = descDiv.Text();
			result = result.Replace("\n", " ").Trim();
			if (result.Length < 1)
			{
				return null;
			}
			return result;
		}

		private string GetData(IElement iElement, string selector, string attribute)
		{
			IElement currentIElement = iElement.QuerySelector(selector);
			string result = currentIElement.GetAttribute(attribute);
			result = result.Replace("\n", " ").Trim();
			return result;
		}

	}
}

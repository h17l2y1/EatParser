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
		public IEnumerable<T> Parse<T>(IDocument document, string restourantId) where T : Product
		{
			IHtmlCollection<IElement> iElementList = document.QuerySelectorAll("div.product-container");

			IEnumerable<T> products = Enumerable
				.Range(0, iElementList.Count())
				.Select(i => CreateProduct<T>(iElementList[i], restourantId));

			return products;
		}

		private T CreateProduct<T>(IElement td, string restourantId) where T : Product
		{
			string fullImage = GetData(td, "img.photo.image.lazy.lazy-loading.lazy-blur", "data-original");
			string cropImage = GetData(td, "source.photo.image.lazy.lazy-loading.lazy-blur", "data-original");
			string desc = GetData(td, "div.short-description");
			string name = GetData(td, "div.name-wrap");
			string priceStr = GetData(td, "span.price");
			string countStr = GetData(td, "div.listing-short-description");
			string weightStr = GetData(td, "div.weight-item");

			int? price = StringToInt(priceStr);
			int? count = countStr == null ? 0 : StringToInt(countStr); ;
			int? weight = StringToInt(weightStr);
			string logo = GetLogoPath(RestaurantType.Yaposhka.ToString());


			T product = CreatProduct<T>(name, desc, weight, count, price, fullImage, restourantId, logo);

			return product;
		}

	}
}

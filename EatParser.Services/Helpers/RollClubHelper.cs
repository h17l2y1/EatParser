using AngleSharp.Dom;
using EatParser.Entities.Entities;
using EatParser.Entities.Types;
using EatParser.Services.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EatParser.Services.Helpers
{
	public class RollClubHelper : BaseHelper, IRollClubHelper
	{
		public List<T> Parse<T>(IDocument document) where T : Product
		{
			IHtmlCollection<IElement> iElementList = document.QuerySelectorAll("div.product-wrap.product-wrap-hasdesc");

			List<T> products = Enumerable
				.Range(0, iElementList.Count())
				.Select(i => CreateProduct<T>(iElementList[i]))
				.ToList();

			return products;
		}

		private T CreateProduct<T>(IElement td) where T : Product
		{
			string name = GetData(td, "a.product-link");
			string desc = GetData(td, "div.product-description__content");
			string weightStr = GetData(td, "span.product-checksize");
			int? weight = StringToInt(weightStr);
			string priceStr = GetData(td, "span.woocommerce-Price-amount.amount");
			int? price = StringToInt(priceStr);
			string fullImage = GetData(td, "img.lazy", "data-src");

			string countStr = SearchCount(desc);
			int? count = StringToInt(countStr);

			T product = CreatProduct<T>(name, desc, weight, count, price, fullImage, (int)RestaurantType.RollClub);

			return product;
		}

		private string SearchCount(string str)
		{
			var words0 = str.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
			var count = words0[words0.Length - 2];

			return count;
		}

		private T CreatePizza<T>(IElement td) where T : Product
		{
			string weightStr = string.Empty;
			string priceStr = string.Empty;

			string name = GetData(td, "a.product-link");
			string desc = GetData(td, "div.product-description__content");
			string fullImage = GetData(td, "img.lazy", "data-src");

			IHtmlCollection<IElement> a = td.QuerySelectorAll("label.variant-pr");
			foreach (var iElement in a)
			{
				priceStr = iElement.QuerySelector("span.woocommerce-Price-amount.amount").Text();
				var size1 = iElement.QuerySelector("span.radio-custom").Text();
			}





			string countStr = SearchCount2(desc);



			//string weightStr = GetData(td, "span.product-checksize");

			int? weight = StringToInt(weightStr);
			int? price = StringToInt(priceStr);
			int? count = StringToInt(countStr);

			T product = CreatProduct<T>(name, desc, weight, count, price, fullImage, (int)RestaurantType.RollClub);

			return product;
		}

		// Состав: моцарелла, бекон, куриное филе, руккола. Количество в порции: 1 шт. Вес: 30 см — 500 г , 40 см — 800 г

		private string SearchCount2(string str)
		{
			var words0 = str.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
			var count = words0[words0.Length - 2];

			return count;
		}
	}
}

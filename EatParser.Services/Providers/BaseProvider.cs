using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using EatParser.Entities.Entities;
using EatParser.Services.Helpers.Interfaces;
using EatParser.Services.Providers.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Providers
{
	public class BaseProvider : IBaseProvider
	{
		protected readonly IHtmlLoaderHelper _htmlLoaderHelper;
		protected readonly IConfiguration _сonfiguration;

		protected readonly HtmlParser domParser;

		public BaseProvider(IHtmlLoaderHelper htmlLoaderHelper, IConfiguration сonfiguration)
		{
			_htmlLoaderHelper = htmlLoaderHelper;
			_сonfiguration = сonfiguration;
			domParser = new HtmlParser();
		}

		public string SetsUrl { get; set; }

		public string RolsUrl { get; set; }

		public string SushiUrl { get; set; }

		public string PizzaUrl { get; set; }

		//public string PageNumber { get; set; } = "page{CurrentId}";

		//public int StartPoint { get; set; }

		//public int EndPoint { get; set; }

		//public async Task<IEnumerable<Set>> GetSets2()
		//{
		//	IEnumerable<Set> result = await ParsePage<Set>(SetsUrl);
		//	return result;
		//}

		public async Task<IDocument> GetDocument(string url)
		{
			IHtmlDocument source = await _htmlLoaderHelper.GetPageSource(url);
			IDocument document = await domParser.ParseDocumentAsync(source);
			return document;
		}

		//private async Task<IEnumerable<T>> ParsePage<T>(string url) where T : Product
		//{
		//	IDocument document = await GetPage(url);
		//	IEnumerable<T> result = _mafia.Parse<T>(document);

		//	return result;
		//}

	}
}

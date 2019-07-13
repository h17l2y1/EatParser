using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using EatParser.Services.Helpers.Interfaces;
using EatParser.Services.Providers.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EatParser.Services.Providers
{
	public class YaposhkaProvider : BaseProvider, IYaposhkaProvider
	{
		protected readonly IHtmlLoaderHelper _htmlLoaderHelper;
		protected readonly string _site = "Yaposhka";

		public YaposhkaProvider(IHtmlLoaderHelper htmlLoaderHelper, IConfiguration сonfiguration)
			: base(htmlLoaderHelper, сonfiguration)
		{
			_htmlLoaderHelper = htmlLoaderHelper;

			BaseUrl = _сonfiguration.GetSection($"Site:{_site}:Url").Value;
			StartPoint = Int32.Parse(_сonfiguration.GetSection($"Site:{_site}:StartPoint").Value);
			EndPoint = Int32.Parse(_сonfiguration.GetSection($"Site:{_site}:EndPoint").Value);
		}

		public async void ggwp()
		{
			var domParser = new HtmlParser();

			var source = await _htmlLoaderHelper.GetPageSource(BaseUrl);
			var document = await domParser.ParseDocumentAsync(source);
			var result = Parse(document);

			//return result;
		}

		private List<string> Parse(IHtmlDocument document)
		{
			var list = new List<string>();
			var items = document.QuerySelectorAll("a")
				.Where(item => item.ClassName != null && item.ClassName.Contains("brander-quickview product-name"));

			foreach (var item in items)
			{
				list.Add(item.TextContent);
			}

			return list;
		}
	}
}

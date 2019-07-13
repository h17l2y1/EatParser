using AngleSharp.Html.Parser;
using EatParser.Services.Helpers.Interfaces;
using EatParser.Services.Providers.Interfaces;
using Microsoft.Extensions.Configuration;
using System;

namespace EatParser.Services.Providers
{
	public class YaposhkaProvider : BaseProvider, IYaposhkaProvider
	{
		protected readonly IYaposhkaHelper _yaposhka;
		protected readonly string _site = "Yaposhka";

		public YaposhkaProvider(IHtmlLoaderHelper htmlLoaderHelper, IConfiguration сonfiguration, IYaposhkaHelper yaposhka)
			: base(htmlLoaderHelper, сonfiguration)
		{
			BaseUrl = _сonfiguration.GetSection($"Site:{_site}:Url").Value;
			StartPoint = Int32.Parse(_сonfiguration.GetSection($"Site:{_site}:StartPoint").Value);
			EndPoint = Int32.Parse(_сonfiguration.GetSection($"Site:{_site}:EndPoint").Value);

			_yaposhka = yaposhka;
		}

		public async void ggwp()
		{
			var source = await _htmlLoaderHelper.GetPageSource(BaseUrl);
			var document = await domParser.ParseDocumentAsync(source);

			var result = _yaposhka.Parse(document);
			var result2 = _yaposhka.Waight(document);
			var result3 = _yaposhka.Count(document);

			//return result;
		}



		//private List<string> Parse(IHtmlDocument document)
		//{
		//	var list = new List<string>();
		//	var items = document.QuerySelectorAll("a")
		//		.Where(item => item.ClassName != null && item.ClassName.Contains("brander-quickview product-name"));

		//	foreach (var item in items)
		//	{
		//		list.Add(item.TextContent);
		//	}

		//	return list;
		//}
	}
}

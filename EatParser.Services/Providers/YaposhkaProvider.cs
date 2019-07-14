using AngleSharp.Html.Parser;
using EatParser.Entities.Entities;
using EatParser.Services.Helpers.Interfaces;
using EatParser.Services.Providers.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

		public async Task<List<SushiSet>> GetYaposhkaSets()
		{
			var source = await _htmlLoaderHelper.GetPageSource(BaseUrl);
			var document = await domParser.ParseDocumentAsync(source);

			List<SushiSet> result = _yaposhka.Parse(document);

			return result;
		}

	}
}

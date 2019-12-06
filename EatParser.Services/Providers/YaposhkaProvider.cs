using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using EatParser.Entities.Entities;
using EatParser.Entities.Types;
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
		protected readonly string _site = RestaurantType.Yaposhka.ToString();

		public YaposhkaProvider(IHtmlLoaderHelper htmlLoaderHelper, IConfiguration сonfiguration, IYaposhkaHelper yaposhka)
			: base(htmlLoaderHelper, сonfiguration)
		{
			SetsUrl = _сonfiguration.GetSection($"Site:{_site}:Sets").Value;
			//StartPoint = Int32.Parse(_сonfiguration.GetSection($"Site:{_site}:StartPoint").Value);
			//EndPoint = Int32.Parse(_сonfiguration.GetSection($"Site:{_site}:EndPoint").Value);

			_yaposhka = yaposhka;
		}

		public async Task<List<Rol>> GetYaposhkaSets()
		{
			IHtmlDocument source = await _htmlLoaderHelper.GetPageSource(SetsUrl);
			IDocument document = await domParser.ParseDocumentAsync(source);

			List<Rol> result = _yaposhka.Parse(document);

			return result;
		}

	}
}

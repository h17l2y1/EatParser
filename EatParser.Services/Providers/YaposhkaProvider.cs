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
			RolsUrl = _сonfiguration.GetSection($"Site:{_site}:Rols").Value;
			SushiUrl = _сonfiguration.GetSection($"Site:{_site}:Sushi").Value;
			PizzaUrl = _сonfiguration.GetSection($"Site:{_site}:Pizza").Value;
			//Pizza2Url = _сonfiguration.GetSection($"Site:{_site}:Pizza2").Value;

			_yaposhka = yaposhka;
		}

		public async Task<List<Set>> GetSets()
		{
			IHtmlDocument source = await _htmlLoaderHelper.GetPageSource(SetsUrl);
			IDocument document = await domParser.ParseDocumentAsync(source);
			List<Set> result = _yaposhka.Parse<Set>(document);

			return result;
		}

		public async Task<List<Rol>> GetRols()
		{
			IHtmlDocument source = await _htmlLoaderHelper.GetPageSource(RolsUrl);
			IDocument document = await domParser.ParseDocumentAsync(source);

			List<Rol> result = _yaposhka.Parse<Rol>(document);

			return result;
		}

		public async Task<List<Sushi>> GetSushi()
		{
			IHtmlDocument source = await _htmlLoaderHelper.GetPageSource(SushiUrl);
			IDocument document = await domParser.ParseDocumentAsync(source);

			List<Sushi> result = _yaposhka.Parse<Sushi>(document);

			return result;
		}

		public async Task<List<Pizza>> GetPizza()
		{
			IHtmlDocument source = await _htmlLoaderHelper.GetPageSource(PizzaUrl);
			IDocument document = await domParser.ParseDocumentAsync(source);

			List<Pizza> result = _yaposhka.Parse<Pizza>(document);

			return result;
		}



	}
}

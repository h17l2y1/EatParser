using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using EatParser.Entities.Entities;
using EatParser.Entities.Types;
using EatParser.Services.Helpers.Interfaces;
using EatParser.Services.Providers.Interfaces;
using Microsoft.Extensions.Configuration;
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
			List<Set> result = await ParsePage<Set>(SetsUrl);
			return result;
		}

		public async Task<List<Rol>> GetRols()
		{
			List<Rol> result = await ParsePage<Rol>(RolsUrl);
			return result;
		}

		public async Task<List<Sushi>> GetSushi()
		{
			List<Sushi> result = await ParsePage<Sushi>(SushiUrl);
			return result;
		}

		public async Task<List<Pizza>> GetPizza()
		{
			List<Pizza> result = await ParsePage<Pizza>(PizzaUrl);
			return result;
		}

		private async Task<List<T>> ParsePage<T>(string url) where T : Product
		{
			IDocument document = await GetPage(url);
			List<T> result = _yaposhka.Parse<T>(document);

			return result;
		}

	}
}

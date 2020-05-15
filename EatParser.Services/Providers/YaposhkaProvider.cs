using AngleSharp.Dom;
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

			_yaposhka = yaposhka;
		}

		public async Task<IEnumerable<Set>> GetSets()
		{
			IEnumerable<Set> result = await ParsePage<Set>(SetsUrl);
			return result;
		}

		public async Task<IEnumerable<Rol>> GetRols()
		{
			IEnumerable<Rol> result = await ParsePage<Rol>(RolsUrl);
			return result;
		}

		public async Task<IEnumerable<Sushi>> GetSushi()
		{
			IEnumerable<Sushi> result = await ParsePage<Sushi>(SushiUrl);
			return result;
		}

		public async Task<IEnumerable<Pizza>> GetPizza()
		{
			IEnumerable<Pizza> result = await ParsePage<Pizza>(PizzaUrl);
			return result;
		}

		private async Task<IEnumerable<T>> ParsePage<T>(string url) where T : Product
		{
			IDocument document = await GetDocument(url);
			//IEnumerable<T> result = _yaposhka.Parse<T>(document);

			return null;
		}

	}
}

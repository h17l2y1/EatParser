using AngleSharp.Dom;
using EatParser.Entities.Entities;
using EatParser.Services.Helpers.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Providers
{
	class YaposhkaProviderFactory : BaseProvider, IProviderFactory
	{
		protected readonly IYaposhkaHelper _yaposhka;
		private IDocument document;
		private readonly Restaurant _restaurant;

		public YaposhkaProviderFactory(IHtmlLoaderHelper htmlLoaderHelper, IConfiguration сonfiguration, IYaposhkaHelper yaposhka, Restaurant restaurant)
			: base(htmlLoaderHelper, сonfiguration)
		{
			_restaurant = restaurant;
			SetsUrl = _сonfiguration.GetSection($"Site:{restaurant.Name}:Sets").Value;
			RolsUrl = _сonfiguration.GetSection($"Site:{restaurant.Name}:Rols").Value;
			SushiUrl = _сonfiguration.GetSection($"Site:{restaurant.Name}:Sushi").Value;
			PizzaUrl = _сonfiguration.GetSection($"Site:{restaurant.Name}:Pizza").Value;
			//Pizza2Url = _сonfiguration.GetSection($"Site:{_site}:Pizza2").Value;

			_yaposhka = yaposhka;
		}

		public async Task<IEnumerable<Set>> GetSets()
		{
			document = await GetDocument(SetsUrl);
			IEnumerable<Set> list = _yaposhka.Parse<Set>(document, _restaurant.Id);
			return list;
		}

		public async Task<IEnumerable<Rol>> GetRols()
		{
			document = await GetDocument(RolsUrl);
			IEnumerable<Rol> list = _yaposhka.Parse<Rol>(document, _restaurant.Id);
			return list;
		}

		public async Task<IEnumerable<Sushi>> GetSushi()
		{
			document = await GetDocument(SushiUrl);
			IEnumerable<Sushi> list = _yaposhka.Parse<Sushi>(document, _restaurant.Id);
			return list;
		}

		public async Task<IEnumerable<Pizza>> GetPizza()
		{
			document = await GetDocument(PizzaUrl);
			IEnumerable<Pizza> list = _yaposhka.Parse<Pizza>(document, _restaurant.Id);
			return list;
		}
	}
}

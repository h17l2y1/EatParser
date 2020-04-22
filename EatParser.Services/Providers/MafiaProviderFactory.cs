using EatParser.Services.Helpers.Interfaces;
using AngleSharp.Dom;
using EatParser.Entities.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Providers
{
	public class MafiaProviderFactory : BaseProvider, IProviderFactory
	{
		protected readonly IMafiaHelper _mafia;
		private IDocument document;
		private readonly Restaurant _restaurant;

		public MafiaProviderFactory(IHtmlLoaderHelper htmlLoaderHelper, IConfiguration сonfiguration, IMafiaHelper mafia, Restaurant restaurant)
		: base(htmlLoaderHelper, сonfiguration)
		{
			_restaurant = restaurant;
			SetsUrl = _сonfiguration.GetSection($"Site:{restaurant.Name}:Sets").Value;
			RolsUrl = _сonfiguration.GetSection($"Site:{restaurant.Name}:Rols").Value;
			SushiUrl = _сonfiguration.GetSection($"Site:{restaurant.Name}:Sushi").Value;
			PizzaUrl = _сonfiguration.GetSection($"Site:{restaurant.Name}:Pizza").Value;

			_mafia = mafia;
		}

		public async Task<IEnumerable<Set>> GetSets()
		{
			document = await GetDocument(SetsUrl);
			//IEnumerable<Product> list = _mafia.Parse<Set>(document, _restaurant.Id);
			IEnumerable<Set> list = _mafia.Parse<Set>(document, _restaurant.Id);
			return list;
		}

		public async Task<IEnumerable<Rol>> GetRols()
		{
			document = await GetDocument(RolsUrl);
			IEnumerable<Rol> list = _mafia.Parse<Rol>(document, _restaurant.Id);
			return list;
		}

		public async Task<IEnumerable<Sushi>> GetSushi()
		{
			document = await GetDocument(SushiUrl);
			IEnumerable<Sushi> list = _mafia.Parse<Sushi>(document, _restaurant.Id);
			return list;
		}

		public async Task<IEnumerable<Pizza>> GetPizza()
		{
			document = await GetDocument(PizzaUrl);
			IEnumerable<Pizza> list = _mafia.Parse<Pizza>(document, _restaurant.Id);
			return list;
		}
	}
}

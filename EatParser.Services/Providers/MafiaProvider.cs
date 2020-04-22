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
	public class MafiaProvider : BaseProvider, IMafiaProvider
	{
		protected readonly IMafiaHelper _mafia;
		protected readonly string _site = RestaurantType.Mafia.ToString();
		private IDocument document;

		public MafiaProvider(IHtmlLoaderHelper htmlLoaderHelper, IConfiguration сonfiguration, IMafiaHelper mafia)
			: base(htmlLoaderHelper, сonfiguration)
		{
			SetsUrl = _сonfiguration.GetSection($"Site:{_site}:Sets").Value;
			RolsUrl = _сonfiguration.GetSection($"Site:{_site}:Rols").Value;
			SushiUrl = _сonfiguration.GetSection($"Site:{_site}:Sushi").Value;
			PizzaUrl = _сonfiguration.GetSection($"Site:{_site}:Pizza").Value;

			_mafia = mafia;
		}

		public async Task All()
		{
			IEnumerable<Set> sets = await GetSets();
			IEnumerable<Rol> rols = await GetRols();
			IEnumerable<Sushi> sushi = await GetSushi();
			IEnumerable<Pizza> pizzas = await GetPizza();

		}

		public async Task<IEnumerable<Set>> GetSets()
		{
			document = await GetDocument(SetsUrl);
			//IEnumerable<Set> list = _mafia.Parse<Set>(document);
			return null;
		}

		public async Task<IEnumerable<Rol>> GetRols()
		{
			document = await GetDocument(SetsUrl);
			//IEnumerable<Rol> list = _mafia.Parse<Rol>(document);
			return null;
		}

		public async Task<IEnumerable<Sushi>> GetSushi()
		{
			document = await GetDocument(SetsUrl);
			//IEnumerable<Sushi> list = _mafia.Parse<Sushi>(document);
			return null;
		}

		public async Task<IEnumerable<Pizza>> GetPizza()
		{
			document = await GetDocument(SetsUrl);
			//IEnumerable<Pizza> list = _mafia.Parse<Pizza>(document);
			return null;
		}

	}
}

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
	public class RollClubProvider : BaseProvider, IRollClubProvider
	{
		protected readonly IRollClubHelper _rollClub;
		protected readonly string _site = RestaurantType.RollClub.ToString();

		public RollClubProvider(IHtmlLoaderHelper htmlLoaderHelper, IConfiguration сonfiguration, IRollClubHelper rollClub)
			: base(htmlLoaderHelper, сonfiguration)
		{
			SetsUrl = _сonfiguration.GetSection($"Site:{_site}:Sets").Value;
			RolsUrl = _сonfiguration.GetSection($"Site:{_site}:Rols").Value;
			SushiUrl = _сonfiguration.GetSection($"Site:{_site}:Sushi").Value;
			PizzaUrl = _сonfiguration.GetSection($"Site:{_site}:Pizza").Value;

			_rollClub = rollClub;
		}

		public async Task<List<Pizza>> GetPizza()
		{
			List<Pizza> result = await ParsePage<Pizza>(PizzaUrl);
			return result;
		}

		public async Task<List<Rol>> GetRols()
		{
			List<Rol> result = await ParsePage<Rol>(RolsUrl);
			return result;
		}

		public async Task<List<Set>> GetSets()
		{
			List<Set> result = await ParsePage<Set>(SetsUrl);
			return result;
		}

		public async Task<List<Sushi>> GetSushi()
		{
			List<Sushi> result = await ParsePage<Sushi>(SushiUrl);
			return result;
		}

		private async Task<List<T>> ParsePage<T>(string url) where T : Product
		{
			IDocument document = await GetPage(url);
			List<T> result = _rollClub.Parse<T>(document);

			return result;
		}
	}
}

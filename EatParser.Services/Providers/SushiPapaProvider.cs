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
	public class SushiPapaProvider : BaseProvider, ISushiPapaProvider
	{
		protected readonly ISushiPapaHelper _sushiPapa;
		protected readonly string _site = RestaurantType.SushiPapa.ToString();

		public SushiPapaProvider(IHtmlLoaderHelper htmlLoaderHelper, IConfiguration сonfiguration, ISushiPapaHelper sushiPapa)
			: base(htmlLoaderHelper, сonfiguration)
		{
			SetsUrl = _сonfiguration.GetSection($"Site:{_site}:Sets").Value;
			RolsUrl = _сonfiguration.GetSection($"Site:{_site}:Rols").Value;
			SushiUrl = _сonfiguration.GetSection($"Site:{_site}:Sushi").Value;

			_sushiPapa = sushiPapa;
		}

		public async Task<List<Rol>> GetRols()
		{
			List<Rol> result = await ParsePage<Rol>(SushiUrl);
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
			List<T> result = _sushiPapa.Parse<T>(document);

			return result;
		}
	}
}

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
	public class MafiaProvider : BaseProvider, IMafiaProvider
	{
		protected readonly IMafiaHelper _mafia;
		protected readonly string _site = RestaurantType.Mafia.ToString();

		public MafiaProvider(IHtmlLoaderHelper htmlLoaderHelper, IConfiguration сonfiguration, IMafiaHelper mafia)
			: base(htmlLoaderHelper, сonfiguration)
		{
			SetsUrl = _сonfiguration.GetSection($"Site:{_site}:Sets").Value;
			RolsUrl = _сonfiguration.GetSection($"Site:{_site}:Rols").Value;
			SushiUrl = _сonfiguration.GetSection($"Site:{_site}:Sushi").Value;
			//StartPoint = Int32.Parse(_сonfiguration.GetSection($"Site:{_site}:StartPoint").Value);
			//EndPoint = Int32.Parse(_сonfiguration.GetSection($"Site:{_site}:EndPoint").Value);

			_mafia = mafia;
		}

		public async Task<List<Set>> GetSets()
		{
			var source = await _htmlLoaderHelper.GetPageSource(SetsUrl);
			var document = await domParser.ParseDocumentAsync(source);
			List<Set> result = _mafia.Parse<Set>(document);

			return result;
		}

		public async Task<List<Rol>> GetRols()
		{
			var source = await _htmlLoaderHelper.GetPageSource(RolsUrl);
			var document = await domParser.ParseDocumentAsync(source);
			List<Rol> result = _mafia.Parse<Rol>(document);

			return result;
		}

		public async Task<List<Sushi>> GetSushi()
		{
			var source = await _htmlLoaderHelper.GetPageSource(SushiUrl);
			var document = await domParser.ParseDocumentAsync(source);
			List<Sushi> result = _mafia.Parse<Sushi>(document);

			return result;
		}
	}
}

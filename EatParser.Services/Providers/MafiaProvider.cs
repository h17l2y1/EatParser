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
	public class MafiaProvider : BaseProvider, IMafiaProvider
	{
		protected readonly IMafiaHelper _mafia;
		protected readonly string _site = RestaurantType.Mafia.ToString();

		public MafiaProvider(IHtmlLoaderHelper htmlLoaderHelper, IConfiguration сonfiguration, IMafiaHelper mafia)
			: base(htmlLoaderHelper, сonfiguration)
		{
			BaseUrl = _сonfiguration.GetSection($"Site:{_site}:Url").Value;
			StartPoint = Int32.Parse(_сonfiguration.GetSection($"Site:{_site}:StartPoint").Value);
			EndPoint = Int32.Parse(_сonfiguration.GetSection($"Site:{_site}:EndPoint").Value);

			_mafia = mafia;
		}

		public async Task<List<RolSet>> GetMafiaSets()
		{
			var source = await _htmlLoaderHelper.GetPageSource(BaseUrl);
			var document = await domParser.ParseDocumentAsync(source);

			List<RolSet> result = _mafia.Parse(document);

			return result;
		}
	}
}

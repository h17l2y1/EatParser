using EatParser.Services.Helpers.Interfaces;
using Microsoft.Extensions.Configuration;

namespace EatParser.Services.Providers
{
	public class BaseProvider
	{
		protected readonly IHtmlLoaderHelper _htmlLoaderHelper;
		protected readonly IConfiguration _сonfiguration;

		public BaseProvider(IHtmlLoaderHelper htmlLoaderHelper, IConfiguration сonfiguration)
		{
			_htmlLoaderHelper = htmlLoaderHelper;
			_сonfiguration = сonfiguration;
		}

		public string BaseUrl { get; set; }

		public string PageNumber { get; set; } = "page{CurrentId}";

		public int StartPoint { get; set; }

		public int EndPoint { get; set; }
	}
}

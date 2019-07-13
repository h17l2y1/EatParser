using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using EatParser.Services.Helpers.Interfaces;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace EatParser.Services.Helpers
{
	public class HtmlLoaderHelper : IHtmlLoaderHelper
	{
		readonly HttpClient client;

		public HtmlLoaderHelper(/*IHabraSettings settings,*/)
		{
			client = new HttpClient();
			//_url = $"{settings.BaseUrl}/{settings.Prefix}/";
		}

		public async Task<IHtmlDocument> GetPageSource(string url)
		{
			var domParser = new HtmlParser();

			//var currentUrl = url.Replace("{CurrentId}", id.ToString());
			//var response = await client.GetAsync(url);
			//string source = null;

			var source = await aaa(url);
			var document = await domParser.ParseDocumentAsync(source);
			return document;
		}

		private async Task<string> aaa(string url)
		{
			var response = await client.GetAsync(url);
			string source = null;

			if (response != null && response.StatusCode == HttpStatusCode.OK)
			{
				source = await response.Content.ReadAsStringAsync();
			}
			return source;
		}

	}
}

using AngleSharp.Html.Parser;
using EatParser.Services.Core.Intefraces;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Parser.Core
{
	public class ParserWorker : IParserWorker
	{
		private readonly IHabraParser _hParser;

		public ParserWorker(IHabraParser hParser)
		{
			_hParser = hParser;
		}

		public async Task<List<string>> Start()
		{
			var domParser = new HtmlParser();

			var source = await GetSourceByPageId();
			var document = await domParser.ParseDocumentAsync(source);
			var result = _hParser.Parse(document);

			return result;
		}

		private async Task<string> GetSourceByPageId()
		{
			var client = new HttpClient();
			var response = await client.GetAsync("https://habrahabr.ru/page1/");
			string source = await response.Content.ReadAsStringAsync();

			return source;
		}


	}

}

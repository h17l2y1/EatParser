using EatParser.Services.Interfaces;
using Parser.Core;
using Parser.Core.Habra;
using System.Threading.Tasks;

namespace EatParser.Services.Services
{
	public class TestService : ITestService
	{
		ParserWorker<string[]> parser;

		public TestService()
		{
			parser = new ParserWorker<string[]>(
					new HabraParser()
				);
		}

		public async Task<string> Get(string str)
		{

			parser.Settings = new HabraSettings(1, 2);
			var result = await parser.Start();

			return "Ok";
		}


	}
}

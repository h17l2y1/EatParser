using EatParser.Services.Core.Intefraces;
using EatParser.Services.Providers.Interfaces;
using EatParser.Services.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Services
{
	public class TestService : ITestService
	{
		private readonly IParserWorker _parser;
		private readonly IYaposhkaProvider _yaposhkaProvider;

		public TestService(IParserWorker parser, IYaposhkaProvider yaposhkaProvider)
		{
			_parser = parser;
			_yaposhkaProvider = yaposhkaProvider;
		}

		public async Task<List<string>> Get(string str)
		{
			var result = await _parser.Start();

			_yaposhkaProvider.ggwp();
			return result;
		}


	}
}

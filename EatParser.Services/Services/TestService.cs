using EatParser.Services.Core.Intefraces;
using EatParser.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Services
{
	public class TestService : ITestService
	{
		private readonly IParserWorker _parser;

		public TestService(IParserWorker parser)
		{
			_parser = parser;
		}

		public async Task<List<string>> Get(string str)
		{
			var result = await _parser.Start();
			return result;
		}


	}
}

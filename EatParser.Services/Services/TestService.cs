using EatParser.Entities.Entities;
using EatParser.Services.Providers.Interfaces;
using EatParser.Services.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Services
{
	public class TestService : ITestService
	{
		private readonly IYaposhkaProvider _yaposhkaProvider;

		public TestService(IYaposhkaProvider yaposhkaProvider)
		{
			_yaposhkaProvider = yaposhkaProvider;
		}

		public async Task<List<SushiSet>> Get(string str)
		{
			var result = await _yaposhkaProvider.GetYaposhkaSets();

			return result;
		}


	}
}

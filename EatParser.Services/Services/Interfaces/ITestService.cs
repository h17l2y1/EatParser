using EatParser.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Services.Interfaces
{
	public interface ITestService
	{
		Task<List<SushiSet>> Get(string str);


	}
}

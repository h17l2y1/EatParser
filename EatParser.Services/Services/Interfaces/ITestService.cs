using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Services.Interfaces
{
	public interface ITestService
	{
		Task<List<string>> Get(string str);


	}
}

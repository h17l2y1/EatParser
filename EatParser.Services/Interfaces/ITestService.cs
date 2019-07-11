using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Interfaces
{
	public interface ITestService
	{
		Task<List<string>> Get(string str);


	}
}

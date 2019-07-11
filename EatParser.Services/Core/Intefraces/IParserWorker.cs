using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Core.Intefraces
{
	public interface IParserWorker
	{
		Task<List<string>> Start();
	}
}

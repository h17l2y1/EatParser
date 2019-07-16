using EatParser.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Providers.Interfaces
{
	public interface IMafiaProvider
	{
		Task<List<SushiSet>> GetMafiaSets();
	}
}

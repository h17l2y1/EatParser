using EatParser.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Helpers.Interfaces
{
	public interface IProviderFactory
	{
		Task<IEnumerable<Set>> GetSets();

		Task<IEnumerable<Rol>> GetRols();

		Task<IEnumerable<Sushi>> GetSushi();

		Task<IEnumerable<Pizza>> GetPizza();
	}
}

using EatParser.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Providers.Interfaces
{
	public interface IBaseProvider
	{
		Task<List<Set>> GetSets();

		Task<List<Rol>> GetRols();

		Task<List<Sushi>> GetSushi();

		Task<List<Pizza>> GetPizza();
	}
}

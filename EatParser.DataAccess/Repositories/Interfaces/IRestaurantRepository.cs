using EatParser.Entities.Entities;
using System.Threading.Tasks;

namespace EatParser.DataAccess.Repositories.Interfaces
{
	public interface IRestaurantRepository : IBaseRepository<Restaurant>
	{
		Task<Restaurant> GetRestaurantByName(string name);
	}
}

using EatParser.DataAccess.Config;
using EatParser.DataAccess.Repositories.Interfaces;
using EatParser.Entities.Entities;
using Microsoft.Extensions.Options;

namespace EatParser.DataAccess.Repositories
{
	public class RestaurantRepository : BaseRepository<Restaurant>, IRestaurantRepository
	{
		public RestaurantRepository(IOptions<ConnectionStrings> connectionConfig) : base(connectionConfig)
		{
		}
	}
}

using Dapper;
using EatParser.DataAccess.Config;
using EatParser.DataAccess.Repositories.Interfaces;
using EatParser.Entities.Entities;
using Microsoft.Extensions.Options;
using System.Data;
using System.Threading.Tasks;

namespace EatParser.DataAccess.Repositories
{
	public class RestaurantRepository : BaseRepository<Restaurant>, IRestaurantRepository
	{
		public RestaurantRepository(IOptions<ConnectionStrings> connectionConfig) : base(connectionConfig)
		{
		}

		public async Task<Restaurant> GetRestaurantByName(string name)
		{
			string sql = @"Select * From Restaurants Where Name = '" + name + "' ";
			Restaurant rest = await Connection.QuerySingleAsync<Restaurant>(sql, commandType: CommandType.Text);
			return rest;
		}

	}
}

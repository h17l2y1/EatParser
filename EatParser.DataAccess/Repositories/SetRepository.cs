using Dapper;
using Dapper.Contrib.Extensions;
using EatParser.DataAccess.Config;
using EatParser.DataAccess.Repositories.Interfaces;
using EatParser.Entities.Entities;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace EatParser.DataAccess.Repositories
{

	public class SetRepository : BaseRepository<Set>, ISetRepository
	{
		public SetRepository(IOptions<ConnectionStrings> connectionConfig) : base(connectionConfig)
		{
		}

		public async Task AddOneDapper(Set set)
		{
			string sql2 = $@"
				INSERT INTO Sets VALUES (@Id, @CreationDate, @Name, @Description, @Weight, @Count, @Price, @Image, @RestaurantId, @Logo)";


			//await Connection.ExecuteAsync(sql2, set);
		}

		public async Task AddOneDapperContrib(Set set)
		{
			await Connection.InsertAsync(set);
		}
	}
}

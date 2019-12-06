using EatParser.DataAccess.Config;
using EatParser.DataAccess.Repositories.Interfaces;
using EatParser.Entities.Entities;
using Microsoft.Extensions.Options;

namespace EatParser.DataAccess.Repositories
{

	public class SushiRepository : BaseRepository<Sushi>, ISushiRepository
	{
		public SushiRepository(IOptions<ConnectionStrings> connectionConfig) : base(connectionConfig)
		{
		}
	}
}


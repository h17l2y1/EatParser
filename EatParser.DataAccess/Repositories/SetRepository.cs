using EatParser.DataAccess.Config;
using EatParser.DataAccess.Repositories.Interfaces;
using EatParser.Entities.Entities;
using Microsoft.Extensions.Options;

namespace EatParser.DataAccess.Repositories
{

	public class SetRepository : BaseRepository<Set>, ISetRepository
	{
		public SetRepository(IOptions<ConnectionStrings> connectionConfig) : base(connectionConfig)
		{
		}
	}
}

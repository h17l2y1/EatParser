using EatParser.DataAccess.Config;
using EatParser.DataAccess.Repositories.Interfaces;
using EatParser.Entities.Entities;
using Microsoft.Extensions.Options;

namespace EatParser.DataAccess.Repositories
{
	public class RolRepository : BaseRepository<Rol>, IRolRepository
	{
		public RolRepository(IOptions<ConnectionStrings> connectionConfig) : base(connectionConfig)
		{
		}
	}
}

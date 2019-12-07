using EatParser.DataAccess.Config;
using EatParser.DataAccess.Repositories.Interfaces;
using EatParser.Entities.Entities;
using Microsoft.Extensions.Options;

namespace EatParser.DataAccess.Repositories
{
	public class PizzaRepository : BaseRepository<Pizza>, IPizzaRepository
	{
		public PizzaRepository(IOptions<ConnectionStrings> connectionConfig) : base(connectionConfig)
		{
		}
	}
}

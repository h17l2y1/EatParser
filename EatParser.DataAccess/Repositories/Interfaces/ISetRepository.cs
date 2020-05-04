using EatParser.Entities.Entities;
using System.Threading.Tasks;

namespace EatParser.DataAccess.Repositories.Interfaces
{
	public interface ISetRepository : IBaseRepository<Set>
	{
		Task AddOneDapper(Set set);

		Task AddOneDapperContrib(Set set);
	}
}

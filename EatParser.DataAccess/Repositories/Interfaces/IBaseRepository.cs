using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.DataAccess.Repositories.Interfaces
{
	public interface IBaseRepository<TEntity> where TEntity : class
	{
		Task<TEntity> Get(string id);

		Task<IEnumerable<TEntity>> GetAll();

		Task Add(TEntity item);

		Task AddRange(IEnumerable<TEntity> entity);

		Task Update(TEntity entity);

		Task Remove(string id);
	}
}

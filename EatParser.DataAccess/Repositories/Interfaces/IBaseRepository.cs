using EatParser.Entities.Entities.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.DataAccess.Repositories.Interfaces
{
	public interface IBaseRepository<TEntity> where TEntity : class
	{
		Task<TEntity> Get(int id);

		Task<IEnumerable<TEntity>> GetAll();

		Task Add(TEntity item);

		Task AddRange(List<TEntity> entity);

		Task Update(TEntity entity);

		Task Remove(int id);
	}
}

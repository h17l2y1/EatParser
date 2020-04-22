using Dapper.Contrib.Extensions;
using EatParser.DataAccess.Config;
using EatParser.DataAccess.Repositories.Interfaces;
using EatParser.Entities.Entities.Interface;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EatParser.DataAccess.Repositories
{
	public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBaseEntity
	{
		protected readonly string _tableName = $"{ typeof(TEntity).Name }s";
		protected readonly string _connectionString;

		protected IDbConnection Connection {
			get { return new SqlConnection(_connectionString); }
		}

		public BaseRepository(IOptions<ConnectionStrings> connectionConfig)
		{
			var connection = connectionConfig.Value;
			_connectionString = connection.DefaultConnection;
		}

		public async Task<TEntity> Get(int id)
		{
			TEntity entity = await Connection.GetAsync<TEntity>(id);
			return entity;
		}

		public async Task<IEnumerable<TEntity>> GetAll()
		{
			return await Connection.GetAllAsync<TEntity>();
		}

		public async Task Add(TEntity item)
		{
			if (item != null)
			{
				await Connection.InsertAsync(item);
			}
		}

		public async Task AddRange(IEnumerable<TEntity> entity)
		{
			if (entity != null)
			{
				await Connection.InsertAsync(entity);
			}
		}

		public async Task Update(TEntity entity)
		{
			if (entity != null)
			{
				await Connection.UpdateAsync(entity);
			}
		}

		public async Task Remove(int id)
		{
			var entity = await Connection.GetAsync<TEntity>(id);
			Connection.Delete(entity);
		}
	}
}

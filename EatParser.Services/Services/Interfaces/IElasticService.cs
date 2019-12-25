using EatParser.Entities.Entities;
using Nest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Services.Interfaces
{
	public interface IElasticService
	{		
		Task<BulkResponse> IndexMany<T>(List<T> list) where T : class;
		
		Task<IndexResponse> IndexOne<T>(T single) where T : class;
		
		Task<IReadOnlyCollection<Person>> Search(string type);
		
	}
}

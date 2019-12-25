using EatParser.Entities.Entities;
using Nest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Services.Interfaces
{
	public interface IElasticService
	{
		Task<IReadOnlyCollection<Person>> Search(string type);

		Task<IndexResponse> Index();

		Task<BulkResponse> IndexMany();

		Task<IndexResponse> IndexFile();

		Task<IReadOnlyCollection<Document>> SearchInFile(string type);

		Task<BulkResponse> NewIndexMany<T>(List<T> list) where T : class;

		Task<IndexResponse> NewIndexOne<T>(T single) where T : class;

		
	}
}

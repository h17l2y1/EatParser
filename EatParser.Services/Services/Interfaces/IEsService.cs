using EatParser.Entities.Entities;
using Nest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Services.Interfaces
{
	public interface IEsService
	{
		Task<IReadOnlyCollection<Person>> Search(string type);

		Task<IndexResponse> Index();

		Task<BulkResponse> IndexMany();

		Task<IndexResponse> IndexFile();

		Task<IReadOnlyCollection<Document>> SearchInFile(string type);
	}
}

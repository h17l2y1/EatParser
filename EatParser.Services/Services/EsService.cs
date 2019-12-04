using EatParser.Entities.Entities;
using EatParser.Services.Providers.Interfaces;
using EatParser.Services.Services.Interfaces;
using Nest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatParser.Services.Services
{
	public class EsService : IEsService
	{
		private readonly ElasticClient _client;

		public EsService(IEsClientProvider clientProvider)
		{
			_client = clientProvider.GetClient();
		}

		public async Task<IndexResponse> Index()
		{
			var person = new Person { 
				Id = 1, 
				FirstName = "Martijn", 
				LastName = "Laarman" 
			};

			IndexResponse indexResponse = await _client.IndexDocumentAsync(person);

			if (!indexResponse.IsValid)
			{
				var ex = indexResponse.OriginalException;
				var debEx = indexResponse.DebugInformation;
			}

			return indexResponse;
		}

		public async Task<BulkResponse> IndexMany()
		{
			List<Person> personList = new List<Person>()
			{
				new Person { Id = 2, FirstName = "Ronaldo", LastName = "Cristiano" },
				new Person { Id = 3, FirstName = "David", LastName = "Beckham" },
				new Person { Id = 4, FirstName = "Leonel", LastName = "Messi" },
			};

			BulkResponse indexManyResponse = await _client.IndexManyAsync(personList);


			if (!indexManyResponse.IsValid)
			{
				var ex = indexManyResponse.OriginalException;
				var debEx = indexManyResponse.DebugInformation;
			}

			return indexManyResponse;
		}

		public async Task<IReadOnlyCollection<Person>> Search(string type)
		{
			ISearchResponse<Person> searchResponse = await _client.SearchAsync<Person>(s => s
					.From(0)
					.Size(10)
					.Query(q => q
						.Match(m => m.Field(f => f.FirstName)
						.Query(type)
						)
					)
			);

			IReadOnlyCollection<Person> people = searchResponse.Documents;
			return people;
		}
	}
}

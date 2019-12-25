using System;
using EatParser.Entities.Entities;
using EatParser.Services.Services.Interfaces;
using Nest;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace EatParser.Services.Services
{
	public class ElasticService : IElasticService
	{
		private readonly IElasticClient _elasticClient;

		public ElasticService(IElasticClient elasticElasticClient)
		{
			_elasticClient = elasticElasticClient;
		}

		public async Task<BulkResponse> IndexMany<T>(List<T> list) where T : class
		{
			var index = typeof(T);

			BulkResponse bulkResponse = await _elasticClient.BulkAsync(b => b
															.Index(index)
															.IndexMany(list));

			if (!bulkResponse.IsValid)
			{
				Exception ex = bulkResponse.OriginalException;
				var debEx = bulkResponse.DebugInformation;
			}

			return bulkResponse;

		}

		public async Task<IndexResponse> IndexOne<T>(T single) where T : class
		{
			var index = typeof(T);
			IndexResponse indexResp = await _elasticClient.IndexAsync(single, i => i.Index(index));

			if (!indexResp.IsValid)
			{
				Exception ex = indexResp.OriginalException;
				var debEx = indexResp.DebugInformation;
			}

			return indexResp;
		}

		// not dynamic
		public async Task<IReadOnlyCollection<Person>> Search(string type)
		{
			ISearchResponse<Person> searchResponse = await _elasticClient.SearchAsync<Person>(s => s
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

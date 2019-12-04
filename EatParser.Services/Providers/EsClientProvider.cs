using EatParser.Services.Providers.Interfaces;
using Microsoft.Extensions.Configuration;
using Nest;
using System;

namespace EatParser.Services.Providers
{
	public class EsClientProvider : IEsClientProvider
	{
		private readonly IConfiguration _configuration;
		private ElasticClient _client;

		public EsClientProvider(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public ElasticClient GetClient()
		{
			if (_client != null)
			{
				return _client;
			}

			var settings = new ConnectionSettings(new Uri(_configuration["EsUrl"])).DefaultIndex("people");
			_client = new ElasticClient(settings);

			return _client;
		}

	}
}

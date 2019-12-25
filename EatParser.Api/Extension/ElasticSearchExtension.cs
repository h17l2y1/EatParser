using EatParser.Entities.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;

namespace EatParser.Api.Extension
{
	public class ElasticSearchExtension
	{
		public void InjectElasticSearch(IServiceCollection services, IConfiguration configuration)
		{
			string url = configuration.GetSection("ElasticUrl")?.Value;
			
			var settings = new ConnectionSettings(new Uri(url))
						   .DefaultMappingFor<Person>(m => m.IndexName("people"))
						   .DefaultMappingFor<RolSet>(m => m.IndexName("rolset"));

			var client = new ElasticClient(settings);

			services.AddSingleton<IElasticClient>(client);
		}
	}
}

using Nest;

namespace EatParser.Services.Providers.Interfaces
{
	public interface IEsClientProvider
	{
		ElasticClient GetClient();
	}
}

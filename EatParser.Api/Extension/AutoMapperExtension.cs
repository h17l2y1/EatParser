using EatParser.Services.Config;
using Microsoft.Extensions.DependencyInjection;

namespace EatParser.Api.Extension
{
	public class AutoMapperExtension
	{
		public void InjectAutoMapper(IServiceCollection services)
		{
			var config = new AutoMapper.MapperConfiguration(c =>
			{
				c.AddProfile(new MapperProfile());
			});
			var mapper = config.CreateMapper();

			services.AddSingleton(mapper);

		}
	}
}

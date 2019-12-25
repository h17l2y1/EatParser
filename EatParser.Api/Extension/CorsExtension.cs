using Microsoft.Extensions.DependencyInjection;

namespace EatParser.Api.Extension
{
	public class CorsExtension
	{
		public void InjectCors(IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("AllowAllPolicy",
					builder => builder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().AllowAnyOrigin().WithExposedHeaders("Token-Expired"));

				options.AddPolicy("OriginPolicy",
					builder => builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().WithOrigins("http://localhost:4200"));
			});
		}
	}
}

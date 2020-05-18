using Microsoft.Extensions.DependencyInjection;

namespace EatParser.Api.Extension
{
	public class CorsExtension
	{
		public static void Add(IServiceCollection services)
		{
			//services.AddCors(options =>
			//{
			//	options.AddPolicy("AllowAllPolicy",
			//		builder => builder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().AllowAnyOrigin().WithExposedHeaders("Token-Expired"));

			//	options.AddPolicy("OriginPolicy",
			//		builder => builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().WithOrigins("http://localhost:4200"));
			//});

			services.AddCors(options =>
			{
				options.AddPolicy("AllowAllPolicy",
					b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials().WithExposedHeaders("Token-Expired"));

				options.AddPolicy("OriginPolicy",
				  b => b.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials());
			});
		}
	}
}

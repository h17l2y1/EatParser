using EatParser.Api.Extension;
using EatParser.Services.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EatParser.Api
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			//services.InjectBusinessLogicDependency(Configuration);

			services.InjectExtension(Configuration);

			//ElasticSearchExtension.InjectElasticSearch(services, Configuration);
			AuthenticationExtension.InjectAuthentication(services, Configuration);
			//CorsExtension.InjectCors(services);

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseCors("AllowAllPolicy");

			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}

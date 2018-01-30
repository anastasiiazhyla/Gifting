using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Gifting.Public
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.Use(async (context, next) => {
				 await next();
				if (context.Response.StatusCode == 404 &&
					 !Path.HasExtension(context.Request.Path.Value) &&
					 !context.Request.Path.Value.StartsWith("/api/"))
				{
					context.Request.Path = "/index.html";
					await next();
				}
			});
			app.UseMvcWithDefaultRoute();
			app.UseDefaultFiles();
			app.UseStaticFiles();





			//app.UseExceptionHandler("/Home/Error"); // Call first to catch exceptions thrown in the following middleware.
			//app.UseStaticFiles();                   // Return static files and end pipeline.

			//app.UseAuthentication();               // Authenticate before you access secure resources.
			//app.UseResponseCompression();			// Static files not compressed by middleware.

			//app.UseMvcWithDefaultRoute();          // Add MVC to the request pipeline.
		}
	}
}

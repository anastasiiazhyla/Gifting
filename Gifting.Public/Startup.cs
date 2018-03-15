using System.Text;
using Gifting.DataAccess.Interfaces;
using Gifting.DataAccess.Repositories;
using Gifting.Models.Models;
using Gifting.Public.Models;
using Gifting.Services;
using Gifting.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Gifting.Public
{
	// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
	public class Startup
	{
		public Startup(IHostingEnvironment env, IConfiguration config)
		{
			HostingEnvironment = env;
			Configuration = config;
		}

		private IHostingEnvironment HostingEnvironment { get; }

		private IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<JWTSettings>(Configuration.GetSection("JWTSettings"));
			services.Configure<DatabaseOptions>(Configuration.GetSection("ConnectionStrings"));
			//services.AddAuthentication()
			//		.AddFacebook(options =>
			//		{
			//			options.AppId = Configuration["Authentication:Facebook:AppId"];                   // from user secrets: Windows: %APPDATA%\microsoft\UserSecrets\<userSecretsId>\secrets.json
			//			options.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
			//		});

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.RequireHttpsMetadata = false; // todo: reconfigure for production
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = Configuration["JWTSettings:Issuer"],
						ValidAudience = Configuration["JWTSettings:Audience"],
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWTSettings:SecretKey"])),
					};
				});

			services.AddMvc();

			RegisterDependencyInjections(services);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			//app.Use(async (context, next) => {
			//	 await next();
			//	if (context.Response.StatusCode == 404 &&
			//		 !Path.HasExtension(context.Request.Path.Value) &&
			//		 !context.Request.Path.Value.StartsWith("/api/"))
			//	{
			//		context.Request.Path = "/index.html";
			//		await next();
			//	}
			//});

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
			}

			app.UseStaticFiles();
			app.UseDefaultFiles();

			app.UseAuthentication(); // Authenticate before you access secure resources.

			// app.UseResponseCompression(); // Static files not compressed by middleware.

			app.UseMvcWithDefaultRoute();
		}

		private void RegisterDependencyInjections(IServiceCollection services)
		{
			// services
			services.AddScoped<IIdeaService, IdeaService>();
			services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<IGranteeService, GranteeService>();
			services.AddScoped<IOccasionService, OccasionService>();

			// repositories
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IIdeaRepository, IdeaRepository>();
			services.AddScoped<IGranteeRepository, GranteeRepository>();
			services.AddScoped<IOccasionRepository, OccasionRepository>();
		}
	}
}

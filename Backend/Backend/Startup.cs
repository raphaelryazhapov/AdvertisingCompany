using System;
using System.IO;
using System.Reflection;
using Backend.Data;
using Backend.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Backend
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers()
				.AddNewtonsoftJson(opts =>
				{
					opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
					opts.SerializerSettings.MaxDepth = 1;
					opts.SerializerSettings.ContractResolver = null;
				});

			services.AddSingleton<AdvertisingCompanyContext, AdvertisingCompanyContext>();

			DependenciesInitializer.ConfigureRepositories(services);

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "1",
					Title = "Advertising Company API",
					Description = "Backend for advertising company project",
					Contact = new OpenApiContact
					{
						Name = "Raphael Ryazhapov",
						Email = string.Empty,
						Url = new Uri("https://github.com/raphaelryazhapov"),
					}
				});

				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				c.IncludeXmlComments(xmlPath);
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Advertisement Company API");
			});

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}

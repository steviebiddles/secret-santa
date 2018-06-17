using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SecretSanta.Data;
using Swashbuckle.AspNetCore.Swagger;
using SecretSanta.Repositories;

namespace SecretSanta
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<SecretSantaContext>();
            services.AddScoped<IEventsRepository, EventsRepository>();

			services.AddRouting(options => options.LowercaseUrls = true);
			services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { 
                    Title = "Secret Santa API",
                    Version = "v1",
                    Description = "A simple secret santa API",
                });
            });
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api/docs/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "api/docs";
                c.SwaggerEndpoint("/api/docs/v1/swagger.json", "Secret Santa API");
            });

			app.UseMvc();
			app.UseMvcWithDefaultRoute();
		}
	}
}

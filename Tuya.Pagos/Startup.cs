using Tuya.Pagos.Filters;
using Tuya.Pagos.Startapp;
using Tuya.Pagos.Resolver.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Tuya.Pagos.ExceptionsHandling;
using Tuya.Pagos.Persistence.Context;
using Tuya.Pagos.Resolver.Application;
using Tuya.Pagos.Resolver.Persistence;
using Microsoft.Extensions.Configuration;
using Tuya.Pagos.Utilities.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace Tuya.Pagos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.ResolveDbContext<PagosContext>();
            services.AddApplicationServices();
            services.AddDomainServices();
            ///Pls see the method AddPersistenceServices to decide what kind of connection do u want
            services.AddPersistenceServices();

            services.AddSwaggerGen( c => {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Practice architecture",
                    Description = "Api Practice architecture"
                });
            });

            services.AddAutoMapper(typeof(GeneralMapper));

            services.AddMvc(config =>
            {
                config.Filters.Add<ControlExceptionFilterAttribute>();
                config.Filters.Add<ResultFilterAttribute>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            Configuration configuration = Configuration.GetSection("Configuration").Get<Configuration>();

            DataConfiguration.SqlConnection = configuration.SqlConnection;
            DataConfiguration.UseDBMemory = configuration.UseDBMemory;

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Practice architecture");
            });
        }
    }
}

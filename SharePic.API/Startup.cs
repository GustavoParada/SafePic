using Domain.Core.Entities;
using Infra.IoC;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;

namespace SharePic.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SafePic Service",
                    Version = "v1",
                    Description = "Endpoints do SafePic APP",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Gustavo Parada",
                        Email = "gustavo@dupa.pt",
                        Url = new Uri("http://www.dupa.pt"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<RabbitMQSettings>(Configuration.GetSection("RabbitMQSettings"));
            services.Configure<MongoDbSettings>(Configuration.GetSection("MongoDbSettings"));

            services.AddMediatR(typeof(Startup));
            services.AddControllers();

            RegisterServices(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SafePic Service V1");
            });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Microservice is active");
            //});

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();
            app.UseHttpsRedirection();
            //app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }

}

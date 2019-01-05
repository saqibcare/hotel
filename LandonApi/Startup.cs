using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LandonApi.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSwag.AspNetCore;

namespace LandonApi
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
            services
                .AddMvc(options =>
                {
                    options.Filters.Add<JsonExceptionFilter>(); //exception are implemented here
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerDocument();

            // Adding this for the routing
            services.AddRouting(options => options.LowercaseUrls = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {

                // Add OpenAPI/Swagger middlewares
                app.UseSwagger(); // Serves the registered OpenAPI/Swagger documents by default on `/swagger/{documentName}/swagger.json`
                app.UseSwaggerUi3(); // Serves the Swagger UI 3 web ui to view the OpenAPI/Swagger documents by default on `/swagger`

            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

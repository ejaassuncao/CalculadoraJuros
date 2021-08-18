using Application.Api.Filter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;
using System.Reflection;

namespace Application.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
               
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                config.Filters.Add(typeof(ExceptionFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            
            .AddJsonOptions(
                    o =>
                    {
                        o.SerializerSettings.Converters.Add(new StringEnumConverter());
                        o.SerializerSettings.Formatting = Formatting.Indented;
                        o.SerializerSettings.NullValueHandling = NullValueHandling.Include;
                        o.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                        o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    }
             );

             services.AddSwaggerGen(option=> {
                 option.SwaggerDoc("calculadoraAPI", new Microsoft.OpenApi.Models.OpenApiInfo {
                     Title="calculado de juros compostos",
                     Version= "1.0.0",
                     Contact = new Microsoft.OpenApi.Models.OpenApiContact
                     {
                         Name = "Elton J. Asunção",
                         Email = "ewa.soft@gmail.com",                       
                         Url =  new Uri("https://github.com/ejaassuncao")
                     }
                 });

                 var xmlComentario = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                 var fullPath = Path.Combine(AppContext.BaseDirectory, xmlComentario);
                 option.IncludeXmlComments(fullPath);

             });

          

            new InjectCDI(services);

        }
       
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger()
                .UseSwaggerUI(option=> {
                    option.RoutePrefix="";
                    option.SwaggerEndpoint("/swagger/calculadoraAPI/swagger.json", "calculadoraapi");
                });

        }
    }
}

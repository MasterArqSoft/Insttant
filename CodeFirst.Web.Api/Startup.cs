using CodeFirst.Core;
using CodeFirst.Core.Features.Pagination;
using CodeFirst.Core.Interfaces.Services;
using CodeFirst.Domain.Settings;
using CodeFirst.Infrastructure;
using CodeFirst.Web.Api.Extensions.App;
using CodeFirst.Web.Api.Extensions.Service;
using CodeFirst.Web.Api.Middlewares;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Linq;

namespace CodeFirst.Web.Api
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
            //Infraeatructura
            services.AddDbContexts(Configuration);
            services.AddRepository();
            //Core
            services.AddCoreLayer();
            //paginacion
            services.AddHttpContextAccessor();
            services.AddSingleton<IUriService>(o =>
            {
                IHttpContextAccessor accessor = o.GetRequiredService<IHttpContextAccessor>();
                HttpRequest request = accessor.HttpContext.Request;
                string uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(uri);
            });
            services.Configure<PaginationOptionsSetting>(options => Configuration.GetSection("Pagination").Bind(options));
            //Configuracion Swagger
            services.AddSwaggerExtension();

            //Configuracion acceso controlador
            services.AddControllers(options =>
            {
                options.Filters.Add<ValidateFilterAttribute>();
            }
            )
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            })
            .AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic));
            });

            //Salud de los servicios
            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerExtension();
            }

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseErrorHandlingMiddleware();

            app.UseHealthChecks("/health");

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
using System.Linq;
using System.Reflection;
using Beacons.AP.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace Beacons.AP
{
    public static class MediatorExtensions
    {
        public static IServiceCollection AddMediatorHandlers(this IServiceCollection services, Assembly assembly)
        {
            var classTypes = assembly.ExportedTypes.Select(t => t.GetTypeInfo()).Where(t => t.IsClass && !t.IsAbstract);

            foreach (var type in classTypes)
            {
                var interfaces = type.ImplementedInterfaces.Select(i => i.GetTypeInfo());

                foreach (var handlerType in interfaces.Where(i => i.IsGenericType &&
                                                                  i.GetGenericTypeDefinition() ==
                                                                  typeof(IRequestHandler<,>)))
                {
                    services.AddTransient(handlerType.AsType(), type.AsType());
                }

                foreach (var handlerType in interfaces.Where(i => i.IsGenericType &&
                                                                  i.GetGenericTypeDefinition() ==
                                                                  typeof(IAsyncRequestHandler<,>)))
                {
                    services.AddTransient(handlerType.AsType(), type.AsType());
                }
            }

            return services;
        }
    }

    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddScoped<IMediator, Mediator>();
            services.AddTransient<SingleInstanceFactory>(sp => t => sp.GetService(t));
            services.AddTransient<MultiInstanceFactory>(sp => t => sp.GetServices(t));
            services.AddMediatorHandlers(typeof(Startup).GetTypeInfo().Assembly);

            // TODO: Fix after update to new version
            //services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            // Assembly sd = typeof(Startup).GetTypeInfo().Assembly;
            // services.AddMediatR();

            services.AddScoped<IBeaconService, BeaconService>();

            // Swagger API documentation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Beacon Api", Version = "v1.0" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            // Swagger API documentation
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Device Api v1.0");
            });
        }
    }
}

using AspNetCoreApi.Common;
using AspNetCoreApi.Contracts;
using AspNetCoreApi.Errors;
using AspNetCoreApi.Filters;
using AspNetCoreApi.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MockRequestData;
using Newtonsoft.Json;

namespace AspNetCoreApi
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
            services.AddOptions();

            services.Configure<HeaderOptions>(Configuration.GetSection("HeaderOptions"));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IRequestMetadata, RequestMetadata>();

            services.AddSingleton<ITelemetryService, TelemetryService>();

            services.AddSingleton<IErrorHandlerService, ErrorHandlerService>();

            services.AddScoped<IExceptionFilter, CustomExceptionFilter>();

            services.AddMvc(options =>
                {
                    options.Filters.Add(typeof(CustomExceptionFilter));
                    options.Filters.Add(new ValidateModelAttribute()); // an instance
                    options.Filters.Add(typeof(EventResourceFilterAttribute)); // by type
                })
                .AddJsonOptions(options =>
                {
                    // Format the JSON string returned from the service.
                    options.SerializerSettings.Formatting = Formatting.Indented;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            ILoggerFactory loggerFactory, IOptions<HeaderOptions> headerOptionsAccessor)
        {
#if DEBUG
            // Adds simulated request header variables to pass security information
            // to the web service when developing locally.
            app.UseMockHeadersMiddleware(new MockHeadersBuilder(headerOptionsAccessor)
              .AddDefaultMockHeadersPolicy()
            );
#endif

            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}

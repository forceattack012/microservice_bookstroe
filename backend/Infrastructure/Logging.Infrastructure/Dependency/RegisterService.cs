using Microsoft.Extensions.DependencyInjection;
using Serilog.Sinks.Elasticsearch;
using Serilog;
using Logging.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Serilog.Events;
using System.Reflection;


namespace Logging.Infrastructure.Dependency
{
    public static class RegisterService
    {
        public static IServiceCollection AddLoggingInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var logger = createLogger(configuration.GetSection("elasticesearch_url").Value ?? "",
                configuration.GetSection("app_name").Value ?? "",
                configuration
            );
            services.AddSingleton<Bookstore.Domain.Repositories.ILogger>(logger);

            return services;
        }


        private static Logger createLogger(string url, string appName, IConfiguration configuration)
        {
            var serilog = new LoggerConfiguration()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                    .Enrich.FromLogContext()
                    .Enrich.WithEnvironmentName()
                    .Enrich.WithMachineName()
                    .WriteTo.Console()
                    .WriteTo.Debug()
                    .Enrich.FromLogContext()
                    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(url))
                    {
                        AutoRegisterTemplate = true,
                        AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv8,
                        IndexFormat = $"{appName}-{Assembly.GetExecutingAssembly().GetName().Name!.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
                    })
                    .ReadFrom.Configuration(configuration)
                    .CreateLogger();

            var logger = new Logger(serilog, appName);
            return logger;
        }
    }
}

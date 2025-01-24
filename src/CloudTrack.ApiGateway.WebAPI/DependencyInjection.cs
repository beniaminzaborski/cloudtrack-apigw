using Azure.Monitor.OpenTelemetry.Exporter;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace CloudTrack.ApiGateway.WebAPI;

public static class DependencyInjection
{
    public static IServiceCollection AddObservability(this IServiceCollection services, IConfiguration config, string serviceName, string serviceVersion)
    {
        var appInsightsConnectionString = GetApplicationInsightsConnectionString(config);

        return services
            .AddOpenTelemetry()
            .WithTracing(builder => builder
                .AddSource(serviceName)
                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(serviceName, serviceVersion: serviceVersion))
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                //.AddConsoleExporter()
                .AddAzureMonitorTraceExporter(cfg => cfg.ConnectionString = appInsightsConnectionString))
            .WithMetrics(builder => builder
                .AddMeter(serviceName)
                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(serviceName, serviceVersion: serviceVersion))
                .AddRuntimeInstrumentation()
                .AddHttpClientInstrumentation()
                .AddAspNetCoreInstrumentation()
                //.AddConsoleExporter()
                .AddAzureMonitorMetricExporter(cfg => cfg.ConnectionString = appInsightsConnectionString))
            .Services;
    }

    private static string? GetApplicationInsightsConnectionString(IConfiguration config) => config.GetConnectionString("ApplicationInsights");
}

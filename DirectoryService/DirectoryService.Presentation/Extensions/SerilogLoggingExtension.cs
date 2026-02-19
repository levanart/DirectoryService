using Serilog;
using Serilog.Exceptions;

namespace DirectoryService.Presentation.Extensions;

public static class SerilogLoggingExtension
{
    public static IServiceCollection AddSerilogLogging(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSerilog((sp, lc) => lc
            .ReadFrom.Configuration(configuration)
            .ReadFrom.Services(sp)
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .Enrich.WithProperty("ServiceName", "DirectoryService")
        );
        
        return services;
    }
}
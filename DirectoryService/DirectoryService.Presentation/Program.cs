using DirectoryService.Application;
using DirectoryService.Infrastructure;
using DirectoryService.Presentation.Extensions;
using DirectoryService.Presentation.Middlewares;
using Microsoft.AspNetCore.Mvc;
using Scalar.AspNetCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting application");
    
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddSerilogLogging(builder.Configuration);

    builder.Services.AddControllers();

    builder.Services.Configure<ApiBehaviorOptions>(options =>
        options.SuppressModelStateInvalidFilter = true);

    builder.Services.AddOpenApi();

    builder.Services.AddInfrastructure();
    builder.Services.AddApplication();
    
    Log.Information("Building application");

    var app = builder.Build();
    
    Log.Information("Build successful");

    app.UseExceptionMiddleware();

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.MapScalarApiReference();
        app.MapGet("/", () => Results.Redirect("/scalar/v1"));
    }

    app.MapControllers();
    
    Log.Information("Starting application");
    
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, ex.Message);
}
finally
{
    Log.Information("Application stopped");
    Log.CloseAndFlush();
}
using System;
using System.IO;
using Backend.SocialNetworkAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace Backend.SocialNetworkAPI;

public class Program
{
    public static int Main(string[] args)
    {
        /*        Log.Logger = new LoggerConfiguration()
        #if DEBUG
                    .MinimumLevel.Debug()
        #else
                    .MinimumLevel.Information()
        #endif
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                    .Enrich.FromLogContext()
                    .WriteTo.Async(c => c.File("Logs/logs.txt"))
                    .WriteTo.Async(c => c.Console())
                    .CreateLogger();*/
        var configBuilderOpts = new AbpConfigurationBuilderOptions();
        configBuilderOpts.EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var config = ConfigurationHelper.BuildConfiguration(configBuilderOpts);
        Log.Logger = new LoggerConfiguration()
                      .ReadFrom.Configuration(config)
                      .CreateLogger();
        try
        {
            Log.Information("Starting web host.");
            CreateHostBuilder(args).Build().Run();
            return 0;
        }
        catch (Exception ex)
        {
            if (ex is HostAbortedException)
            {
                throw;
            }

            Log.Fatal(ex, "Host terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .AddAppSettingsSecretsJson()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseAutofac()
                .UseSerilog();
}
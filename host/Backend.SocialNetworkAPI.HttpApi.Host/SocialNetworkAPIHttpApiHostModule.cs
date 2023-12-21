using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Backend.SocialNetworkAPI.EntityFrameworkCore;
using StackExchange.Redis;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;

using Volo.Abp.VirtualFileSystem;
using System.Reflection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Elastic.Apm.NetCoreAll;
using Elastic.Apm.DiagnosticSource;
using Elastic.Apm.EntityFrameworkCore;
using Elastic.Apm;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using Volo.Abp.Auditing;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Backend.SocialNetworkAPI;

[DependsOn(
        typeof(SocialNetworkAPIApplicationModule),
        typeof(SocialNetworkAPIEntityFrameworkCoreModule),
        typeof(SocialNetworkAPIHttpApiModule),
        typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
        typeof(AbpAutofacModule),
        typeof(AbpCachingStackExchangeRedisModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule),
        typeof(AbpAuditLoggingEntityFrameworkCoreModule),
        //TODO Enable when we need to store permission and setting in required db. Disable in template.
        //typeof(AbpPermissionManagementEntityFrameworkCoreModule),
        //typeof(AbpSettingManagementEntityFrameworkCoreModule),
        typeof(AbpAspNetCoreSerilogModule),
        //typeof(AbpEventBusRabbitMqModule),
        //TODO Enable this if we use kafka instead of rabbitmq
        //typeof(AbpKafkaModule),
        typeof(AbpSwashbuckleModule),
        typeof(AbpAuditingModule),
        typeof(AbpSwashbuckleModule)
    )]
public class SocialNetworkAPIHttpApiHostModule : AbpModule
{
    private readonly string _apiVersion = typeof(SocialNetworkAPIHttpApiHostModule).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
    private readonly string _apiTitle = "SocialNetwork API";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        Configure<AbpDbContextOptions>(options =>
        {
            options.UseSqlServer();
        });

        if (hostingEnvironment.IsDevelopment())
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.ReplaceEmbeddedByPhysical<SocialNetworkAPIDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}Backend.SocialNetworkAPI.Domain.Shared", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<SocialNetworkAPIDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}Backend.SocialNetworkAPI.Domain", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<SocialNetworkAPIApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}Backend.SocialNetworkAPI.Application.Contracts", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<SocialNetworkAPIApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}Backend.SocialNetworkAPI.Application", Path.DirectorySeparatorChar)));
            });
        }

        context.Services.AddAbpSwaggerGenWithOAuth(
            configuration["AuthServer:Authority"]!,
            new Dictionary<string, string>
            {
                {"SocialNetworkAPI", _apiTitle}
            },
            options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = _apiTitle + $" - {hostingEnvironment.EnvironmentName ?? ""}", Version = _apiVersion });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
            });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Languages.Add(new LanguageInfo("vi", "vi", "Vietnamese"));
            options.Languages.Add(new LanguageInfo("en", "en", "English"));
        });

        context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });

        Configure<AbpDistributedCacheOptions>(options =>
        {
            options.KeyPrefix = "SocialNetworkAPI:";
        });

        var dataProtectionBuilder = context.Services.AddDataProtection().SetApplicationName("SocialNetworkAPI");
        if (!hostingEnvironment.IsDevelopment())
        {
            var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]!);
            dataProtectionBuilder.PersistKeysToStackExchangeRedis(redis, "SocialNetworkAPI-Protection-Keys");
        }

        context.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(
                        configuration["App:CorsOrigins"]?
                            .Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(o => o.RemovePostFix("/"))
                            .ToArray() ?? Array.Empty<string>()
                    )
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
        ConfigureHealthChecks(context, configuration);
    }

    private void ConfigureHealthChecks(ServiceConfigurationContext context, IConfiguration configuration)
    {
        //add more health check at here
        context.Services.AddHealthChecks()
                 .AddSqlServer(
                    connectionString: configuration["ConnectionStrings:Default"],
                    name: "database",
                    failureStatus: HealthStatus.Degraded,
                    tags: new string[] { "db", "sql", "sqlserver" }
                );
        //.AddRedis(
        //    redisConnectionString: configuration["Redis:Configuration"],
        //    name: "redis",
        //    failureStatus: HealthStatus.Degraded,
        //    tags: new string[] { "db", "redis" }
        //);
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {

        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        var _configuration = context.GetConfiguration();
        app.UseAllElasticApm(_configuration);
        Agent.Subscribe(new HttpDiagnosticsSubscriber());
        Agent.Subscribe(new EfCoreDiagnosticsSubscriber());

        app.UseAuthentication();
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        /*app.UseCors();*/
        /*if (MultiTenancyConsts.IsEnabled)
        {
            app.UseMultiTenancy();
        }*/
        app.UseAbpRequestLocalization(opt =>
        {
            opt.SetDefaultCulture("vi");
            //opt.DefaultRequestCulture = new RequestCulture("vi");
            opt.AddSupportedUICultures("vi");
            opt.AddSupportedCultures("vi");
        });
        /*app.UseAuthorization();*/
        app.UseSwagger();
        app.UseAbpSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Support APP API");

            var configuration = context.GetConfiguration();
            options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
            options.OAuthClientSecret(configuration["AuthServer:SwaggerClientSecret"]);
            options.OAuthScopes("SocialNetworkAPI");
        });
        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseHealthChecks("/health", new HealthCheckOptions()
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        app.UseConfiguredEndpoints();
    }
}
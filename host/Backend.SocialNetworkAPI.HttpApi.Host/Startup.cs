using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Localization;
using Volo.Abp.Settings;
using Microsoft.Extensions.Logging;

namespace Backend.SocialNetworkAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<SocialNetworkAPIHttpApiHostModule>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.ApplicationServices.GetService<ISettingDefinitionManager>().GetAsync(LocalizationSettingNames.DefaultLanguage).Result.DefaultValue = "vi";
            app.InitializeApplication();
        }
    }
}
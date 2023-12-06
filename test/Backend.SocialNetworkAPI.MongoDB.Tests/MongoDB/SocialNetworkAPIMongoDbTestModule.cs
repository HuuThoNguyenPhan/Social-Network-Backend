using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Uow;

namespace Backend.SocialNetworkAPI.MongoDB;

[DependsOn(
    typeof(SocialNetworkAPITestBaseModule),
    typeof(SocialNetworkAPIMongoDbModule)
    )]
public class SocialNetworkAPIMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = MongoDbFixture.GetRandomConnectionString();
        });
    }
}

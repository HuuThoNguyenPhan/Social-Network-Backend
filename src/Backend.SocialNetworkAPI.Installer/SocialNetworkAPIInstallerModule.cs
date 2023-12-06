using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Backend.SocialNetworkAPI;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class SocialNetworkAPIInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SocialNetworkAPIInstallerModule>();
        });
    }
}

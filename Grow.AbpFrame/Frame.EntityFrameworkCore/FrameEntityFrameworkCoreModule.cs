namespace Frame.EntityFrameworkCore;

[DependsOn(
    typeof(AbpEntityFrameworkCoreModule), 
    typeof(AbpEntityFrameworkCorePostgreSqlModule))]
public class FrameEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<NovelDbContext>(options =>
        {
            //includeAllEntities=true => 除了聚合外, 在每個實體上也都會創建倉儲
            options.AddDefaultRepositories();
        });

        Configure<AbpDbContextOptions>(options =>
        {
            options.UseNpgsql();
        });
    }
}
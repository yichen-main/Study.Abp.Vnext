namespace Frame.TestBase;

[DependsOn(typeof(AbpAutofacModule), typeof(AbpTestBaseModule), typeof(FrameDomainModule))]
public class FrameTestBaseModule : AbpModule
{
    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        //建立數據播種(會執行所有繼承 IDataSeedContributor 接口的播種類)
        AsyncHelper.RunSync(async () =>
        {
            using var scope = context.ServiceProvider.CreateScope();
            await scope.ServiceProvider.GetRequiredService<IDataSeeder>().SeedAsync();
        });
    }
}
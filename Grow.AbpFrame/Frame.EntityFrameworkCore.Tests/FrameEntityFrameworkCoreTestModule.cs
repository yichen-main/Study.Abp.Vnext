namespace Frame.EntityFrameworkCore.Tests;

[DependsOn(
    typeof(FrameTestBaseModule),
    typeof(FrameEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreSqliteModule))]
public class FrameEntityFrameworkCoreTestModule : AbpModule
{
    SqliteConnection _sqliteConnection = null!;
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        //獲取連接物件
        _sqliteConnection = CreateDatabaseAndGetConnection();

        //配置資料庫
        Configure<AbpDbContextOptions>(options =>
        {
            //獲取上下文
            options.Configure(item => item.DbContextOptions.UseSqlite(_sqliteConnection));
        });
    }
    public override void OnApplicationShutdown(ApplicationShutdownContext context) => _sqliteConnection.Dispose();
    static SqliteConnection CreateDatabaseAndGetConnection()
    {
        //連接資料庫(記憶體)
        SqliteConnection connection = new("Data Source=:memory:");
        connection.Open();

        //獲取 NovelDbContext 內的 DbSet 上下文
        var options = new DbContextOptionsBuilder<NovelDbContext>().UseSqlite(connection).Options;

        //創建表結構
        using var context = new NovelDbContext(options);
        context.GetService<IRelationalDatabaseCreator>().CreateTables();
        return connection;
    }
}
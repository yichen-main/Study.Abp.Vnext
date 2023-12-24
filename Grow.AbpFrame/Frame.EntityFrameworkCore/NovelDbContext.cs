namespace Frame.EntityFrameworkCore;

[ConnectionStringName("Novel")] //連接字符串的配置檔欄位名稱
public class NovelDbContext(DbContextOptions<NovelDbContext> options) : AbpDbContext<NovelDbContext>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //引入 Mappings 資料夾內的 Table 配置
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    //作者
    public DbSet<Author> Authors { get; set; }

    //書本
    public DbSet<Book> Books { get; set; }
    public DbSet<Volume> Volumes { get; set; }
    public DbSet<Chapter> Chapters { get; set; }
    public DbSet<ChapterText> ChapterTexts { get; set; }

    //類別
    public DbSet<Category> Categories { get; set; }
}
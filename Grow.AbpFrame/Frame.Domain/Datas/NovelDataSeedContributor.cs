namespace Frame.Domain.Datas;

[Dependency(ServiceLifetime.Transient)]
public class NovelDataSeedContributor : IDataSeedContributor /*數據種子類*/
{
    readonly List<Guid> _guids = [];
    readonly IRepository<Book, Guid> _bookRepository;
    readonly IRepository<Author, Guid> _authorRepository;
    readonly IRepository<Category, Guid> _categoryRepository;
    public NovelDataSeedContributor(
        IGuidGenerator guidGenerator, //ABP 提供的 GUID 生成器
        IRepository<Book, Guid> bookRepository,
        IRepository<Author, Guid> authorRepository,
        IRepository<Category, Guid> categoryRepository)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
        _categoryRepository = categoryRepository;

        for (int i = 0; i < 3; i++) _guids.Add(guidGenerator.Create());
    }

    //播種方法
    public async Task SeedAsync(DataSeedContext context)
    {
        await CreateBookAsync();
        await CreateAuthorAsync();
        await CreateCategoryAsync();
    }

    //創建數據種子(書本)
    public async Task CreateBookAsync()
    {
        Book book = new(
            _guids[2], "三體", "科幻小說史詩巨著",
            _guids[0], "國鑫",
            _guids[1], "科幻");
        book.AddVolume("三體1");
        book.Volumes[0].AddChapter("第一章", "正文1");

        await _bookRepository.InsertAsync(book);
    }

    //創建數據種子(作者)
    public async Task CreateAuthorAsync()
    {
        await _authorRepository.InsertAsync(new(_guids[0], "國鑫", "不知名小說家"));
    }

    //創建數據種子(類別)
    public async Task CreateCategoryAsync()
    {
        await _categoryRepository.InsertAsync(new(_guids[1], "科幻"));
    }
}
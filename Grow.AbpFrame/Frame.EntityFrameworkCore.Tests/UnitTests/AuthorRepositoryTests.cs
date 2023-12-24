namespace Frame.EntityFrameworkCore.Tests.UnitTests;
public sealed class AuthorRepositoryTests : FrameEntityFrameworkCoreTestBase
{
    readonly IGuidGenerator _guidGenerator; //ABP 提供的 GUID 生成器
    readonly IRepository<Author, Guid> _authorRepository;
    public AuthorRepositoryTests()
    {
        _guidGenerator = GetRequiredService<IGuidGenerator>();
        _authorRepository = GetRequiredService<IRepository<Author, Guid>>();
    }

    [Fact]
    public void Should_ABC()
    {
        string result = "123";

        //斷言: 結果是否為空
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task Should_Insert_A_Valid_Author()
    {
        Author testAuthor = new(_guidGenerator.Create(), "國鑫", "不知名小說家");

        //插入測試
        await WithUnitOfWorkAsync(async () =>
        {
            await _authorRepository.InsertAsync(testAuthor);
        });

        //驗證測試(可以不需要)
        var result = await WithUnitOfWorkAsync(async () =>
        {
            return await _authorRepository.FirstOrDefaultAsync(author => author.Id == testAuthor.Id);
        });

        //斷言: 結果是否為空
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task Should_Get_List_of_Authors()
    {
        var result = await WithUnitOfWorkAsync(async () => await _authorRepository.GetListAsync());

        //斷言: 結果是否大於 0
        result.Count.ShouldBeGreaterThan(0);
    }
}
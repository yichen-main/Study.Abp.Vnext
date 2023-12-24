namespace Frame.EntityFrameworkCore.Repositories;
public class BookRepository(IDbContextProvider<NovelDbContext> dbContextProvider) :
    EfCoreRepository<NovelDbContext, Book, Guid>(dbContextProvider), IBookRepository
{
    public async Task<Chapter> FindChapterByIdAsync(Guid id, bool include = true, CancellationToken cancellationToken = default)
    {
        var chapters = (await GetDbContextAsync()).Chapters;
        var result = await chapters.IncludeIf(include, chapter => chapter.ChapterText)
            .FirstOrDefaultAsync(chapter => chapter.Id == id, GetCancellationToken(cancellationToken));
        return result;
    }
}
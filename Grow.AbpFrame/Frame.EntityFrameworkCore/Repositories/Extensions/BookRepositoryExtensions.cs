namespace Frame.EntityFrameworkCore.Repositories.Extensions;
public static class BookRepositoryExtensions
{
    public static Chapter FindChapterById(this IBookRepository repository, Guid id, bool include = true)
    {
        return AsyncHelper.RunSync(() => repository.FindChapterByIdAsync(id, include));
    }
}
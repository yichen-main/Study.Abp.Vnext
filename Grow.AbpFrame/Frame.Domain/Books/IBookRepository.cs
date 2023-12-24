namespace Frame.Domain.Books;
public interface IBookRepository : IRepository<Book, Guid> /*聚合根用的泛型倉儲接口<實體類, 識別碼>*/
{
    //尋找章節編號
    Task<Chapter> FindChapterByIdAsync(Guid id, bool include = true, CancellationToken cancellationToken = default);
}
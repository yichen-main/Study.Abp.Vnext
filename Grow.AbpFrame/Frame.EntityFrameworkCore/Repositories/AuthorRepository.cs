namespace Frame.EntityFrameworkCore.Repositories;
public class AuthorRepository(IDbContextProvider<NovelDbContext> dbContextProvider) : 
    EfCoreRepository<NovelDbContext, Author, Guid>(dbContextProvider), IAuthorRepository
{

}
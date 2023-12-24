namespace Frame.EntityFrameworkCore.Repositories;
public class CategoryRepository(IDbContextProvider<NovelDbContext> dbContextProvider) :
    EfCoreRepository<NovelDbContext, Category, Guid>(dbContextProvider), ICategoryRepository
{

}
namespace Frame.Domain.Categories;
public interface ICategoryRepository : IRepository<Category, Guid> /*聚合根用的泛型倉儲接口<實體類, 識別碼>*/
{

}
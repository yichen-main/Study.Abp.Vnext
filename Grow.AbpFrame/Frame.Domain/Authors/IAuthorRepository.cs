namespace Frame.Domain.Authors;
public interface IAuthorRepository : IRepository<Author, Guid> /*聚合根用的泛型倉儲接口<實體類, 識別碼>*/
{

}
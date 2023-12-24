namespace Frame.Domain.Categories;
public class Category : AuditedAggregateRoot<Guid> /*審計屬性: 創建者ID、創建時間、更新者ID、更新者時間*/
{
    public Category() { }
    public Category(Guid id, string name)
    {
        Id = id;
        Name = Check.NotNullOrWhiteSpace(name, nameof(name));
    }
    public string Name { get; set; } = null!;
}
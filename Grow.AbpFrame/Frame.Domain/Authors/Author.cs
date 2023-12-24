namespace Frame.Domain.Authors;
public class Author : AggregateRoot<Guid>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    protected Author() { }
    public Author(Guid id, string name, string description)
    {
        Id = id;
        Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        Description = description;
    }
}
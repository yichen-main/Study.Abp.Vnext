namespace Sample.Novel.Domain.Books;
public class Book : AuditedAggregateRoot<Guid>
{/*帶有審計屬性的聚合根(審計屬性: 創建者ID、創建時間、更新者ID、更新時間)*/
    public string Name { get; set; }
    public string Description { get; set; }

    public Guid AuthorId { get; set; }
    public string AuthorName { get; set; }

    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }

    public List<Volume> Volumes { get; protected set; }
    protected Book() { } //提供給 ORM 框架用
    public Book(
        Guid id, string name, string description,
        Guid authorId, string authorName,
        Guid categoryId, string categoryName)
    {
        Id = id;
        Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        Description = Check.NotNullOrWhiteSpace(description, nameof(description));
        AuthorId = authorId;
        AuthorName = Check.NotNullOrWhiteSpace(authorName, nameof(authorName));
        CategoryId = categoryId;
        CategoryName = Check.NotNullOrWhiteSpace(categoryName, nameof(categoryName));
        Volumes = [];
    }
    public void AddVolume(string title, string description)
    {
        //防止添加標題相同的分卷
        if (Volumes.Any(volume => volume.Title == title)) return;

        //添加分卷
        Volumes.Add(new Volume(title, description));
    }
    public void RemoveVolume(Guid volumeId)
    {
        //刪除指定分卷
        Volumes.RemoveAll(volume => volume.Id == volumeId);
    }
}
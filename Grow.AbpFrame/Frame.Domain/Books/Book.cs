﻿namespace Frame.Domain.Books;
public class Book : AuditedAggregateRoot<Guid> /*審計屬性: 創建者ID、創建時間、更新者ID、更新者時間*/
{
    protected Book() { }
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

    //添加分卷
    public void AddVolume(string title, string? description = default)
    {
        //防止添加標題相同的分卷
        if (Volumes.Any(volume => volume.Title == title)) return;

        Volumes.Add(new Volume(title, description ?? string.Empty));
    }

    //刪除指定分卷
    public void RemoveVolume(Guid volumeId) => Volumes.RemoveAll(volume => volume.Id == volumeId);

    //書本
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

    //作者
    public Guid AuthorId { get; set; }
    public string AuthorName { get; set; } = null!;

    //類別
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;

    //分卷(導航屬性)
    public List<Volume> Volumes { get; protected set; } = null!;
}
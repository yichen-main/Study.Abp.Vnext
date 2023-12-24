namespace Sample.Novel.Domain.Books;
public class Volume : Entity<Guid>, IHasCreationTime /*審計接口*/
{
    public Book Book { get; set; }
    public Guid BookId { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }

    public List<Chapter> Chapters { get; protected set; }

    public DateTime CreationTime { get; }

    protected Volume() { } //提供給 ORM 框架用
    public Volume(string title, string description)
    {
        Title = title;
        Description = description;
        Chapters = [];
    }

    //添加章節
    public void AddVolume(string title, string? content = default)
    {
        //防止添加標題相同的章節
        if (Chapters.Any(volume => volume.Title == title)) return;

        Chapters.Add(new Chapter(title, content ?? string.Empty));
    }

    //刪除指定章節
    public void RemoveVolume(Guid chapterId)
    {
        Chapters.RemoveAll(chapter => chapter.Id == chapterId);
    }
}
namespace Frame.Domain.Books;
public class Volume : Entity<Guid>, IHasCreationTime /*審計接口: 只有創建時間*/
{
    protected Volume() { }
    public Volume(string title, string description)
    {
        Title = title;
        Description = description;
        Chapters = [];
    }

    //添加章節
    public void AddChapter(string title, string content)
    {
        //防止添加標題相同的章節
        if (Chapters.Any(volume => volume.Title == title)) return;

        Chapters.Add(new Chapter(title, content));
    }

    //刪除指定章節
    public void RemoveChapter(Guid chapterId) => Chapters.RemoveAll(chapter => chapter.Id == chapterId);
    public Guid BookId { get; set; }
    public Book Book { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;

    //章節(導航屬性)
    public List<Chapter> Chapters { get; protected set; } = null!;
    public DateTime CreationTime { get; }
}
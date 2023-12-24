namespace Frame.Domain.Books;
public class Chapter : Entity<Guid>, IHasCreationTime /*審計接口: 只有創建時間*/
{
    protected Chapter() { }
    public Chapter(string title, string content, string authorMessage = "")
    {
        WordNumber = content.Length;
        ChapterText = new ChapterText(content, authorMessage);
        Title = Check.NotNullOrWhiteSpace(title, nameof(title)); 
    }
    public Guid VolumeId { get; set; }
    public Volume Volume { get; set; } = null!;
    public string Title { get; set; } = null!;
    public int WordNumber { get; set; }

    //章節內容(導航屬性)
    public ChapterText ChapterText { get; protected set; } = null!;
    public DateTime CreationTime { get; }
}
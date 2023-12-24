namespace Frame.Domain.Books;
public class ChapterText : AuditedEntity<Guid>
{
    protected ChapterText() { }
    public ChapterText(string content, string authorMessage = "")
    {
        AuthorMessage = authorMessage;
        Content = Check.NotNullOrWhiteSpace(content, nameof(content));     
    }
    public Chapter Chapter { get; set; } = null!;
    public string Content { get; set; } = null!;
    public string AuthorMessage { get; set; } = null!;
}
namespace Sample.Novel.Domain.Books;
public class ChapterText : AuditedEntity<Guid> /*帶有審計屬性的實體*/
{
    public Chapter Chapter { get; set; }

    public string Content { get; set; }
    public string AuthorMessage { get; set; }
    protected ChapterText() { } //提供給 ORM 框架用
    public ChapterText(string content, string authorMessage)
    {
        Content = Check.NotNullOrWhiteSpace(content, nameof(content));
        AuthorMessage = authorMessage;
    }
}
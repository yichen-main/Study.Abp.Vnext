namespace Frame.EntityFrameworkCore.Mappings;
public class BookMap : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable(nameof(Book));
        builder.ConfigureByConvention();

        builder.Property(book => book.Name)
            .HasMaxLength(20)
            .IsRequired(); //不能為空

        builder.Property(book => book.Description)
            .HasMaxLength(200)
            .IsRequired(); //不能為空

        builder.Property(book => book.AuthorName)
            .HasMaxLength(20)
            .IsRequired(); //不能為空

        builder.Property(book => book.CategoryName)
            .HasMaxLength(10)
            .IsRequired(); //不能為空
    }
}
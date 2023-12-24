namespace Frame.EntityFrameworkCore.Mappings;
public class AuthorMap : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable(nameof(Author));
        builder.ConfigureByConvention();

        builder.Property(author => author.Name)
            .HasMaxLength(20)
            .IsRequired(); //不能為空

        builder.Property(author => author.Description)
            .HasMaxLength(100)
            .IsRequired(); //不能為空
    }
}
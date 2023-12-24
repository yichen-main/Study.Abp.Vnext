namespace Frame.EntityFrameworkCore.Mappings;
public class ChapterTextMap : IEntityTypeConfiguration<ChapterText>
{
    public void Configure(EntityTypeBuilder<ChapterText> builder)
    {
        builder.ToTable(nameof(ChapterText));
        builder.ConfigureByConvention();

        builder.Property(text => text.Content)
            .HasColumnType("ntext")
            .HasMaxLength(8000)
            .IsRequired(); //不能為空

        builder.Property(text => text.AuthorMessage)
         .HasMaxLength(2000);
    }
}
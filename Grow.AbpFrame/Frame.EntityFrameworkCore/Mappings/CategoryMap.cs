namespace Frame.EntityFrameworkCore.Mappings;
public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable(nameof(Category));
        builder.ConfigureByConvention();

        builder.Property(category => category.Name)
            .HasMaxLength(10)
            .IsRequired(); //不能為空
    }
}
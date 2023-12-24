namespace Frame.EntityFrameworkCore.Mappings;
public class VolumeMap : IEntityTypeConfiguration<Volume>
{
    public void Configure(EntityTypeBuilder<Volume> builder)
    {
        builder.ToTable(nameof(Volume));
        builder.ConfigureByConvention();

        builder.Property(volume => volume.Title)
            .HasMaxLength(20)
            .IsRequired(); //不能為空

        builder.Property(volume => volume.Description)
            .HasMaxLength(100)
            .IsRequired(); //不能為空
    }
}
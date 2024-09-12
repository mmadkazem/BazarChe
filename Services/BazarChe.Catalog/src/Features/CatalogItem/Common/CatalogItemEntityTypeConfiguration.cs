namespace src.Features.CatalogItem.Common;


public sealed class CatalogItemEntityTypeConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable(Item.TableName);

        builder.HasKey(x => x.Slug);
        builder.Property(x => x.Slug)
            .HasMaxLength(150);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(5000);

        builder.Property(x => x.Price)
            .HasColumnType("decimal(15,2)");

        builder.OwnsMany(x => x.Medias, builder =>
        {
            builder.ToJson();

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Url)
                .HasMaxLength(1098)
                .IsRequired();
        });
    }
}
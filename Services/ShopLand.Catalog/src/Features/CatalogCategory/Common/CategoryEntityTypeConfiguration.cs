namespace src.Features.CatalogCategory.Common;


public sealed class CatalogCategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable(Category.TableName);

        builder.HasKey(x => x.Id);

        builder.Ignore(x => x.Path);

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired(true);

        builder.Property(x => x.ParentId)
            .IsRequired(false);

        builder.HasMany(x => x.Children)
            .WithOne(z => z.Parent)
            .HasForeignKey(x => x.ParentId);
    }
}
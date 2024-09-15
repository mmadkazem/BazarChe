namespace Catalog.Api.Features.CatalogCategory.Common;

public class Category
{
    public const string TableName = "CatalogCategories";

    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public int? ParentId { get; private set; }
    public string? Path => GetPath(this);

    public Category Parent { get; private set; } = null!;
    public ICollection<Category> Children { get; private set; } = null!;

    private Category(string name, int? parentId)
    {
        Name = name;
        ParentId = parentId;
    }

    private string? GetPath(Category category)
    {
        if (category.Parent is not null)
            return $"{GetPath(category.Parent)}/{category.Name}";

        if (category.Id == Id)
            return null;

        return category.Name;
    }

    public static Category Create(string name, int? parentId)
        => new(name, parentId);

    public void Update(string name)
        => Name = name;
}

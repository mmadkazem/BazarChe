namespace Catalog.Api.Features.CatalogBrand.Common;


public class Brand
{
    public const string TableName = "Brands";

    public int Id { get; set; }
    public string Name { get; private set; } = null!;

    private Brand(string name)
        => Name = name;

    public void Update(string name)
        => Name = name;

    public static Brand Create(string name)
        => new(name);
}
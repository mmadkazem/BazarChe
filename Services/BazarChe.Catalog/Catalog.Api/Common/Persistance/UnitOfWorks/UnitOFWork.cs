namespace Catalog.Api.Common.Persistance.UnitOfWorks;

public sealed class UnitOfWork(CatalogDbContext context,
        ICatalogItemRepository catalogItems,
        ICategoryRepository categories,
        IBrandRepository brands
    ) : IUnitOfWork
{
    private readonly CatalogDbContext _context = context;

    private readonly ICategoryRepository _categories = categories;
    public ICategoryRepository Categories => _categories;

    private readonly IBrandRepository _brands = brands;
    public IBrandRepository Brands => _brands;

    private readonly ICatalogItemRepository _catalogItems = catalogItems;
    public ICatalogItemRepository CatalogItems => _catalogItems;

    public Task SaveChangesAsync(CancellationToken token)
        => _context.SaveChangesAsync(token);
}
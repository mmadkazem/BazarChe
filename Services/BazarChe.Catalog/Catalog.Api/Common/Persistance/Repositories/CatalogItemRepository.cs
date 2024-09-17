namespace Catalog.Api.Common.Persistance.Repositories;



public sealed class CatalogItemRepository(CatalogDbContext context) : ICatalogItemRepository
{
    private readonly CatalogDbContext _context = context;

    public void Add(Item item)
        => _context.Items.Add(item);

    public void Remove(Item item)
        => _context.Items.Remove(item);

    public async Task<bool> AnyAsync(Expression<Func<Item, bool>> expression, CancellationToken token = default)
        => await _context.Items.AsQueryable()
                                .AnyAsync(expression, token);

    public async Task<Item?> FirstOrDefaultAsync(Expression<Func<Item, bool>> expression, CancellationToken token = default)
        => await _context.Items.AsQueryable()
                                .FirstOrDefaultAsync(expression, token);

    public async Task<Item> FirstAsync(Expression<Func<Item, bool>> expression, CancellationToken token = default)
    => await _context.Items.AsQueryable()
                            .Include(ci => ci.CatalogBrand)
                            .Include(ci => ci.CatalogCategory)
                            .FirstAsync(expression, token);

    public async Task<CatalogItemQueryResponse?> Get(Expression<Func<Item, bool>> expression, CancellationToken token = default)
        => await _context.Items.AsQueryable()
                                .Where(expression)
                                .Select(i => new CatalogItemQueryResponse
                                (
                                    i.Name,
                                    i.Slug,
                                    i.Description,
                                    i.BrandId,
                                    i.CatalogBrand.Name,
                                    i.CatalogCategoryId,
                                    i.CatalogCategory.Name,
                                    i.Price,
                                    i.AvailableStock,
                                    i.MaxStockThreshold,
                                    i.Medias.ToImmutableList()
                                )).FirstOrDefaultAsync(token);

    public async Task<IEnumerable<CatalogItemQueryResponse>> GetAll(int page, int sizePage, CancellationToken token = default)
        => await _context.Items.AsQueryable()
                                .OrderBy(c => c.Name)
                                .Select(x => new CatalogItemQueryResponse
                                (
                                    x.Name,
                                    x.Slug,
                                    x.Description,
                                    x.BrandId,
                                    x.CatalogBrand.Name,
                                    x.CatalogCategoryId,
                                    x.CatalogCategory.Name,
                                    x.Price,
                                    x.AvailableStock,
                                    x.MaxStockThreshold,
                                    x.Medias.ToImmutableList()
                                ))
                                .Skip((page - 1) * sizePage)
                                .Take(sizePage)
                                .ToListAsync(token);
}
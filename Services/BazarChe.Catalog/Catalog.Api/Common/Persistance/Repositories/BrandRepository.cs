namespace Catalog.Api.Common.Persistance.Repositories;


public sealed class BrandRepository(CatalogDbContext context) : IBrandRepository
{
    private readonly CatalogDbContext _context = context;

    public void Add(Brand brand)
        => _context.Brands.Add(brand);

    public Task<bool> AnyAsync(Expression<Func<Brand, bool>> expression, CancellationToken token)
        => _context.Brands.AsQueryable()
                            .AnyAsync(expression, token);

    public async Task<Brand?> FirstOrDefaultAsync(Expression<Func<Brand, bool>> expression, CancellationToken token)
        => await _context.Brands.AsQueryable()
                            .FirstOrDefaultAsync(expression, token);

    public Task<GetBrandQueryResponse> Get(Expression<Func<Brand, bool>> expression, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GetBrandQueryResponse>> GetAll(CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public void Remove(Brand brand)
        => _context.Brands.Remove(brand);
}
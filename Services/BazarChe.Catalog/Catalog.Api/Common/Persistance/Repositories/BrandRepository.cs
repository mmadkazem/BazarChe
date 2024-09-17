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

    public async Task<GetBrandQueryResponse?> Get(Expression<Func<Brand, bool>> expression, CancellationToken token = default)
        => await _context.Brands.AsQueryable()
                                .Where(expression)
                                .Select(b => new GetBrandQueryResponse
                                (
                                    b.Id,
                                    b.Name
                                ))
                                .FirstOrDefaultAsync(token);
    public async Task<IEnumerable<GetBrandQueryResponse>> GetAll(CancellationToken token = default)
        => await _context.Brands.AsQueryable()
                                    .Select(b => new GetBrandQueryResponse
                                    (
                                        b.Id,
                                        b.Name
                                    ))
                                    .ToListAsync(token);

    public void Remove(Brand brand)
        => _context.Brands.Remove(brand);
}
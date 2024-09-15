namespace Catalog.Api.Common.Persistance.Repositories;


public sealed class CategoryRepository(CatalogDbContext context) : ICategoryRepository
{
    private readonly CatalogDbContext _context = context;

    public void Add(Category category)
        => _context.Categories.Add(category);

    public void Remove(Category category)
        => _context.Categories.Remove(category);

    public async Task<bool> AnyAsync(Expression<Func<Category, bool>> expression, CancellationToken token = default)
        => await _context.Categories.AsQueryable()
                                    .AnyAsync(expression, token);

    public async Task<Category?> FirstOrDefaultAsync(Expression<Func<Category, bool>> expression, CancellationToken token = default)
        => await _context.Categories.AsQueryable()
                                    .FirstOrDefaultAsync(expression, token);

    public async Task<Category?> FirstOrDefaultAsyncIncludeChildren(Expression<Func<Category, bool>> expression, CancellationToken token = default)
        => await _context.Categories.AsQueryable()
                                    .Include(c => c.Children)
                                    .FirstOrDefaultAsync(expression, token);

    public async Task<GetCategoryByIdQueryResponse?> Get(Expression<Func<Category, bool>> expression, CancellationToken token = default)
        => await _context.Categories.AsQueryable()
                                    .Where(expression)
                                    .Select(c => new GetCategoryByIdQueryResponse(c.Id, c.Name, c.Path))
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(token);

    public async Task<IEnumerable<GetCategoriesQueryResponse>> GetAll(CancellationToken token = default)
        => await _context.Categories.AsQueryable()
                                    .OrderBy(c => c.Id)
                                    .Select(x => new GetCategoriesQueryResponse(x.Id, x.Name, x.Path))
                                    .AsNoTracking()
                                    .ToListAsync(token);
}
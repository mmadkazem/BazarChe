namespace src.Features.CatalogCategory.Common;


public interface ICategoryRepository
{
    void Add(Category category);
    void Remove(Category category);
    Task<bool> AnyAsync(Expression<Func<Category, bool>> expression, CancellationToken token = default);
    Task<Category?> FirstOrDefaultAsync(Expression<Func<Category,bool>> expression, CancellationToken token = default);
    Task<Category?> FirstOrDefaultAsyncIncludeChildren(Expression<Func<Category,bool>> expression, CancellationToken token = default);
    Task<GetCategoryByIdQueryResponse?> Get(Expression<Func<Category,bool>> expression, CancellationToken token = default);
    Task<IEnumerable<GetCategoriesQueryResponse>> GetAll(CancellationToken token = default);
}
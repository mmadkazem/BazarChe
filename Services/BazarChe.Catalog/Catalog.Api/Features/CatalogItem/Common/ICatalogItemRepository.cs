using Catalog.Api.Features.CatalogItem.UseCase.Queries;

namespace Catalog.Api.Features.CatalogItem.Common;

public interface ICatalogItemRepository
{
    void Add(Item item);
    void Remove(Item item);
    Task<Item?> FirstOrDefaultAsync(Expression<Func<Item, bool>> expression, CancellationToken token = default);
    Task<bool> AnyAsync(Expression<Func<Item, bool>> expression, CancellationToken token = default);
    Task<Item> FirstAsync(Expression<Func<Item, bool>> expression, CancellationToken token = default);
    Task<CatalogItemQueryResponse?> Get(Expression<Func<Item, bool>> expression, CancellationToken token = default);
    Task<IEnumerable<CatalogItemQueryResponse>> GetAll(int page, int sizePage, CancellationToken token = default);
}
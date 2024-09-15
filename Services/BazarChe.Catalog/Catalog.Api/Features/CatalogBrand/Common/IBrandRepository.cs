using Catalog.Api.Features.CatalogBrand.UseCase.Queries;

namespace Catalog.Api.Features.CatalogBrand.Common;

public interface IBrandRepository
{
    void Add(Brand brand);
    Task<bool> AnyAsync(Expression<Func<Brand, bool>> expression, CancellationToken token = default);
    Task<Brand?> FirstOrDefaultAsync(Expression<Func<Brand, bool>> expression, CancellationToken token = default);
    Task<IEnumerable<GetBrandQueryResponse>> GetAll(CancellationToken token = default);
    Task<GetBrandQueryResponse> Get(Expression<Func<Brand, bool>> expression, CancellationToken token = default);
    void Remove(Brand brand);
}
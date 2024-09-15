namespace Catalog.Api.Features.CatalogBrand.UseCase.Queries.GetBrands;


public sealed class GetBrandsQueryRequest : IRequest<Results<Ok<IEnumerable<GetBrandQueryResponse>>, NotFound<string>>>;

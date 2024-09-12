namespace src.Features.CatalogBrand.UseCase.Queries.GetBrandById;


public sealed record GetBrandByIdQueryRequest(int Id) : IRequest<Results<Ok<GetBrandQueryResponse>, NotFound<string>>>;

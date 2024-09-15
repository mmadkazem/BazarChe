using Catalog.Api.Common.Persistance.UnitOfWorks;

namespace Catalog.Api.Features.CatalogBrand.UseCase.Queries.GetBrands;

public sealed class GetBrandsQueryHandler(IUnitOfWork uow) : IRequestHandler<GetBrandsQueryRequest, Results<Ok<IEnumerable<GetBrandQueryResponse>>, NotFound<string>>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Results<Ok<IEnumerable<GetBrandQueryResponse>>, NotFound<string>>> Handle(GetBrandsQueryRequest request, CancellationToken token)
    {
        var responses = await _uow.Brands.GetAll(token);
        if (!responses.Any())
        {
            return TypedResults.NotFound("Brands not found");
        }

        return TypedResults.Ok(responses);
    }
}
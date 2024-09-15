using Catalog.Api.Common.Persistance.UnitOfWorks;

namespace Catalog.Api.Features.CatalogBrand.UseCase.Queries.GetBrandById;


public sealed class GetBrandByIdQueryHandler(IUnitOfWork uow) : IRequestHandler<GetBrandByIdQueryRequest, Results<Ok<GetBrandQueryResponse>, NotFound<string>>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Results<Ok<GetBrandQueryResponse>, NotFound<string>>> Handle(GetBrandByIdQueryRequest request, CancellationToken token)
    {
        var response = await _uow.Brands.Get(b => b.Id == request.Id, token);
        if (response is null)
        {
            return TypedResults.NotFound($"Brand with id {request.Id} not found.");
        }

        return TypedResults.Ok(response);
    }
}
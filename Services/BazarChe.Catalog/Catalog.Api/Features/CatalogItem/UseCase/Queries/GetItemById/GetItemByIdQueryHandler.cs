namespace Catalog.Api.Features.CatalogItem.UseCase.Queries.GetItemById;

public sealed class GetItemByIdQueryHandler(IUnitOfWork uow) : IRequestHandler<GetItemByIdQueryRequest, Results<Ok<CatalogItemQueryResponse?>, NotFound>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Results<Ok<CatalogItemQueryResponse?>, NotFound>> Handle(GetItemByIdQueryRequest request, CancellationToken token)
    {
        var response = await _uow.CatalogItems.Get(ci => ci.Slug == request.Slug, token);
        if (response is null)
        {
            return TypedResults.NotFound();
        }
        return TypedResults.Ok(response);
    }
}
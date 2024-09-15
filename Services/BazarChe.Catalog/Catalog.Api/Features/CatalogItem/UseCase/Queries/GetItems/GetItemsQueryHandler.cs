namespace Catalog.Api.Features.CatalogItem.UseCase.Queries.GetItems;

public sealed class GetItemsQueryHandler(IUnitOfWork uow) : IRequestHandler<GetItemsQueryRequest, Results<Ok<IEnumerable<CatalogItemQueryResponse>>, NotFound>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Results<Ok<IEnumerable<CatalogItemQueryResponse>>, NotFound>> Handle(GetItemsQueryRequest request, CancellationToken token)
    {
        var responses = await _uow.CatalogItems.GetAll(request.Page, request.SizePage, token);

        if (!responses.Any())
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(responses);
    }
}
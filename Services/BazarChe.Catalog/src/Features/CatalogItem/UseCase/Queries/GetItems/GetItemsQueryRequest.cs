namespace src.Features.CatalogItem.UseCase.Queries.GetItems;


public sealed record GetItemsQueryRequest(int Page, int SizePage)
    : IRequest<Results<Ok<IEnumerable<CatalogItemQueryResponse>>, NotFound>>;

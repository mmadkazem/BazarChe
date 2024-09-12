namespace src.Features.CatalogItem.UseCase.Queries.GetItemById;

public sealed record GetItemByIdQueryRequest(string Slug)
    : IRequest<Results<Ok<CatalogItemQueryResponse?>, NotFound>>;

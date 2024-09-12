namespace src.Features.CatalogItem.UseCase.Commands.CreateItem;


public sealed record CreateItemCommandRequest
(
    string Name,
    string Description,
    int CatalogId,
    int BrandId,
    int MaxStockThreshold
) : IRequest<Results<Created, BadRequest<string>>>;

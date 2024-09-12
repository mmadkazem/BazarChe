namespace src.Features.CatalogItem.UseCase.Queries;

public readonly record struct CatalogItemQueryResponse
(
    string Name,
    string Slug,
    string Description,
    int BrandId,
    string BrandName,
    int CategoryId,
    string CategoryName,
    decimal Price,
    int AvailableStock,
    int MaxStockThreshold,
    IReadOnlyList<Media> Medias
);

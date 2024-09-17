namespace Catalog.Api.Features.CatalogItem.UseCase.Queries;


public sealed record CatalogItemQueryResponse
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

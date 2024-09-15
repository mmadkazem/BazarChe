namespace Catalog.Api.Features.CatalogItem.UseCase.Commands.UpdateMaxStockThreshold;


public sealed record UpdateCatalogItemMaxStockThresholdCommandRequest(string Slug, int MaxStockThreshold)
    : IRequest<Results<Created, NotFound<string>>>;

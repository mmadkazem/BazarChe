namespace Catalog.Api.Features.CatalogItem.Common.Exceptions;

public sealed class EmptyStockException(string name)
    : CatalogDomainBaseException($"Empty stock, product item {name} is sold out");

namespace Catalog.Api.Features.CatalogItem.Common.Exceptions;

public sealed class PriceGreaterThanZeroException()
    : CatalogDomainBaseException("Item price desired should be greater than zero");

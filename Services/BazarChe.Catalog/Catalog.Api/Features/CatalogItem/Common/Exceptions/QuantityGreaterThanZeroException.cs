namespace Catalog.Api.Features.CatalogItem.Common.Exceptions;

public sealed class QuantityGreaterThanZeroException()
    : CatalogDomainBaseException("Item units desired should be greater than zero");
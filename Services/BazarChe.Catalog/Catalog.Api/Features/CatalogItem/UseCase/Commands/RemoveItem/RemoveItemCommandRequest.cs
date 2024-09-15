namespace Catalog.Api.Features.CatalogItem.UseCase.Commands.RemoveItem;

public sealed record RemoveItemCommandRequest(string Slug)
    : IRequest<Results<NoContent, NotFound, BadRequest<string>>>;

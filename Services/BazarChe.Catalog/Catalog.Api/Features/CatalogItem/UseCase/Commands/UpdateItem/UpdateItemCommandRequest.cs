namespace Catalog.Api.Features.CatalogItem.UseCase.Commands.UpdateItem;


public sealed record UpdateItemCommandRequest
(
    string Slug,
    string Description,
    int CategoryId,
    int BrandId
) : IRequest<Results<Created, NotFound<string>, BadRequest<string>>>
{
    public static UpdateItemCommandRequest Create(string slug, UpdateItemDTO model)
        => new(slug, model.Description, model.CategoryId, model.BrandId);
}

public readonly record struct UpdateItemDTO
(
    string Description,
    int CategoryId,
    int BrandId
);
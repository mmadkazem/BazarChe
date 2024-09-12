namespace src.Features.CatalogItem.UseCase.Commands.UpdateItem;

public sealed class UpdateItemCommandHandler(IUnitOfWork uow) : IRequestHandler<UpdateItemCommandRequest, Results<Created, NotFound<string>, BadRequest<string>>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Results<Created, NotFound<string>, BadRequest<string>>> Handle(UpdateItemCommandRequest request, CancellationToken token)
    {
        var Item = await _uow.CatalogItems.FirstOrDefaultAsync(i => i.Slug == request.Slug, token);
        if (Item is null)
        {
            return TypedResults.NotFound($"Item with slug {request.Slug} not found.");
        }

        var hasCategory = await _uow.Categories.AnyAsync(x => x.Id == request.CategoryId, token);
        if (!hasCategory)
        {
            return TypedResults.BadRequest($"A category Id is not valid.");
        }

        var hasBrand = await _uow.Brands.AnyAsync(x => x.Id == request.BrandId, token);
        if (!hasBrand)
        {
            return TypedResults.BadRequest($"A brand Id is not valid.");
        }

        Item.Update(request.Description,
                    request.BrandId,
                    request.CategoryId);

        await _uow.SaveChangesAsync(token);

        var loadedItem = await _uow.CatalogItems.FirstAsync(x => x.Slug == Item.Slug, token);

        var detailUrl = $"/catalog/api/v1/items/{loadedItem.Slug}";

        // await services.Publish.Publish(new CatalogItemChangedEvent(
        //         loadedItem.Name,
        //         loadedItem.Description,
        //         loadedItem.CatalogCategory.Category,
        //         loadedItem.CatalogBrand.Brand,
        //         loadedItem.Slug,
        //         detailUrl));

        return TypedResults.Created(detailUrl);
    }
}
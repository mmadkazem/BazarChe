namespace src.Features.CatalogItem.UseCase.Commands.CreateItem;

public sealed class CreateItemCommandHandler(IUnitOfWork uow) : IRequestHandler<CreateItemCommandRequest, Results<Created, BadRequest<string>>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Results<Created, BadRequest<string>>> Handle(CreateItemCommandRequest request, CancellationToken token)
    {
        var hasCategory = await _uow.Categories.AnyAsync(x => x.Id == request.CatalogId, token);
        if (!hasCategory)
        {
            return TypedResults.BadRequest($"A category Id is not valid.");
        }

        var hasBrand = await _uow.Brands.AnyAsync(x => x.Id == request.BrandId, token);
        if (!hasBrand)
        {
            return TypedResults.BadRequest($"A brand Id is not valid.");
        }

        var hasItemSlug = await _uow.CatalogItems.AnyAsync(x => x.Slug == request.Name.ToKebabCase(), token);
        if (hasItemSlug)
        {
            return TypedResults.BadRequest($"A Item with the slug '{request.Name.ToKebabCase()}' already exists.");
        }

        var item = Item.Create(
            request.Name,
            request.Description,
            request.MaxStockThreshold,
            request.BrandId, request.CatalogId);

        _uow.CatalogItems.Add(item);
        await _uow.SaveChangesAsync(token);

        var detailUrl = $"/catalog/api/v1/items/{item.Slug}";
        // var loadedItem = await _uow.CatalogItems.FirstAsync(x => x.Slug == item.Slug, token);
        // await services.Publish.Publish(new CatalogItemAddedEvent(
        //         loadedItem.Name,
        //         loadedItem.Description,
        //         loadedItem.CatalogCategory.Category,
        //         loadedItem.CatalogBrand.Brand,
        //         loadedItem.Slug,
        //         detailUrl));

        return TypedResults.Created(detailUrl);
    }
}
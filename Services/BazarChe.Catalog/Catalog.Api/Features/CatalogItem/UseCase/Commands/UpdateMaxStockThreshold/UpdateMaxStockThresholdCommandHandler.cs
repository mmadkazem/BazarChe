namespace Catalog.Api.Features.CatalogItem.UseCase.Commands.UpdateMaxStockThreshold;

public sealed class UpdateMaxStockThresholdCommandHandler(IUnitOfWork uow) : IRequestHandler<UpdateCatalogItemMaxStockThresholdCommandRequest, Results<Created, NotFound<string>>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Results<Created, NotFound<string>>> Handle(UpdateCatalogItemMaxStockThresholdCommandRequest request, CancellationToken cancellationToken)
    {
        var Item = await _uow.CatalogItems.FirstOrDefaultAsync(i => i.Slug == request.Slug, cancellationToken);
        if (Item is null)
        {
            return TypedResults.NotFound($"Item with Slug {request.Slug} not found.");
        }

        Item.SetMaxStockThreshold(request.MaxStockThreshold);

        await _uow.SaveChangesAsync(cancellationToken);

        return TypedResults.Created($"/catalog/api/v1/items/{Item.Slug}");
    }
}
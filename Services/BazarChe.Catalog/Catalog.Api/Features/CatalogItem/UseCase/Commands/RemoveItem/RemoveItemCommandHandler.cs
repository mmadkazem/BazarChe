namespace Catalog.Api.Features.CatalogItem.UseCase.Commands.RemoveItem;

public sealed class RemoveItemCommandHandler(IUnitOfWork uow) : IRequestHandler<RemoveItemCommandRequest, Results<NoContent, NotFound, BadRequest<string>>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Results<NoContent, NotFound, BadRequest<string>>> Handle(RemoveItemCommandRequest request, CancellationToken token)
    {
        var item = await _uow.CatalogItems.FirstOrDefaultAsync(x => x.Slug == request.Slug);
        if (item is null)
        {
            return TypedResults.NotFound();
        }

        _uow.CatalogItems.Remove(item);
        await _uow.SaveChangesAsync(token);
        return TypedResults.NoContent();
    }
}
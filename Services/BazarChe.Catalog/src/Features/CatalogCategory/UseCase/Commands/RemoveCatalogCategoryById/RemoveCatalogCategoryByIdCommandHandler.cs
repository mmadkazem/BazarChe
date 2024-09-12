namespace src.Features.CatalogCategory.UseCase.Commands.RemoveCatalogCategoryById;

public sealed class RemoveCatalogCategoryByIdCommandHandler(IUnitOfWork uow) : IRequestHandler<RemoveCatalogCategoryByIdCommandRequest, Results<NoContent, NotFound<string>, BadRequest<string>>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Results<NoContent, NotFound<string>, BadRequest<string>>> Handle(RemoveCatalogCategoryByIdCommandRequest request, CancellationToken token)
    {
        var category = await _uow.Categories.FirstOrDefaultAsync(x => x.Id == request.Id, token);
        if (category is null)
        {
            return TypedResults.NotFound($"Category with this ID: {request.Id} was not found");
        }

        if (category.Children.Count != 0)
        {
            return TypedResults.BadRequest("The category has child categories and cannot be deleted.");
        }

        _uow.Categories.Remove(category);
        await _uow.SaveChangesAsync(token);
        return TypedResults.NoContent();
    }
}
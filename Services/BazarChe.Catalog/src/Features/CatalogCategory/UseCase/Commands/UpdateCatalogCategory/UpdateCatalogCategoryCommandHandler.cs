namespace src.Features.CatalogCategory.UseCase.Commands.UpdateCatalogCategory;

public sealed class UpdateCatalogCategoryCommandHandler(IUnitOfWork uow) : IRequestHandler<UpdateCatalogCategoryCommandRequest, Results<Created, NotFound<string>>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Results<Created, NotFound<string>>> Handle(UpdateCatalogCategoryCommandRequest request, CancellationToken token)
    {
        var category = await _uow.Categories.FirstOrDefaultAsync(i => i.Id == request.Id, token);
        if (category is null)
        {
            return TypedResults.NotFound($"Category with id {request.Id} not found.");
        }

        category.Update(request.Name);
        await _uow.SaveChangesAsync(token);

        return TypedResults.Created($"/catalog/api/v1/categories/{category.Id}");
    }
}
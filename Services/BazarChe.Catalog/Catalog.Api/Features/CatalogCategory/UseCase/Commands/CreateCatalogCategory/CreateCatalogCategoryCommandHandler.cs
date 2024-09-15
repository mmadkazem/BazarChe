namespace Catalog.Api.Features.CatalogCategory.UseCase.Commands.CreateCatalogCategory;

public sealed class CreateCatalogCategoryCommandHandler(IUnitOfWork uow) : IRequestHandler<CreateCatalogCategoryCommandRequest, Results<Created, BadRequest<string>>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Results<Created, BadRequest<string>>> Handle(CreateCatalogCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.ParentId.HasValue)
        {
            var hasParent = await _uow.Categories.AnyAsync(x => x.Id == request.ParentId, cancellationToken);
            if (!hasParent)
            {
                return TypedResults.BadRequest($"A parent Id is not valid.");
            }
        }

        var hasCategory = await _uow.Categories.AnyAsync(x => x.Name == request.Category &&
                                                            x.ParentId == request.ParentId, cancellationToken);
        if (hasCategory)
        {
            return TypedResults.BadRequest($"A Category with the name '{request.Category}' in this level already exists.");
        }

        var category = Category.Create(request.Category, request.ParentId);

        _uow.Categories.Add(category);
        await _uow.SaveChangesAsync(cancellationToken);

        return TypedResults.Created($"/catalog/api/v1/categories/{category.Id}");
    }
}
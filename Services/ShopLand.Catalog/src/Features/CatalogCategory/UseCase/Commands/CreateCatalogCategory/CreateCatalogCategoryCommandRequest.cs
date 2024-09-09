namespace src.Features.CatalogCategory.UseCase.Commands.CreateCatalogCategory;


public sealed record CreateCatalogCategoryCommandRequest(string Category, int? ParentId)
    : IRequest<Results<Created, BadRequest<string>>>;

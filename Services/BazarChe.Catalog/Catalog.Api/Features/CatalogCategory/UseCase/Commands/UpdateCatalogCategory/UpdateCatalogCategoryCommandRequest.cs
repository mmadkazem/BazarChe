namespace Catalog.Api.Features.CatalogCategory.UseCase.Commands.UpdateCatalogCategory;


public sealed record UpdateCatalogCategoryCommandRequest(int Id, string Name)
    : IRequest<Results<Created, NotFound<string>>>;

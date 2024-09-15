namespace Catalog.Api.Features.CatalogCategory.UseCase.Commands.RemoveCatalogCategoryById;


public sealed record RemoveCatalogCategoryByIdCommandRequest(int Id)
    : IRequest<Results<NoContent, NotFound<string>, BadRequest<string>>>;
namespace Catalog.Api.Features.CatalogCategory.UseCase.Queries.GetCategories;


public sealed record GetCategoriesQueryRequest()
    : IRequest<Results<Ok<IEnumerable<GetCategoriesQueryResponse>>, NotFound<string>>>;
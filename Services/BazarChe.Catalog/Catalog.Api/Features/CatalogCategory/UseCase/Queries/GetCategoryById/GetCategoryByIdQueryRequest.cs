namespace Catalog.Api.Features.CatalogCategory.UseCase.Queries.GetCategoryById;


public sealed record GetCategoryByIdQueryRequest(int Id)
    : IRequest<Results<Ok<GetCategoryByIdQueryResponse>, NotFound<string>>>;

public sealed record GetCategoryByIdQueryResponse(int Id, string Name, string? Path);
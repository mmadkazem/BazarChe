namespace Catalog.Api.Features.CatalogCategory.UseCase.Queries.GetCategories;

public sealed record GetCategoriesQueryResponse(int Id, string Name, string? Path);
namespace Catalog.Api.Features.CatalogBrand.UseCase.Commands.RemoveBrand;



public sealed record RemoveBrandCommandRequest(int Id) : IRequest<Results<NoContent, NotFound<string>>>;
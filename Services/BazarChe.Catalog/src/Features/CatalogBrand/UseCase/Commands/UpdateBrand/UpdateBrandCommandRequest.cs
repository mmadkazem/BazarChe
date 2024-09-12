namespace src.Features.CatalogBrand.UseCase.Commands.UpdateBrand;


public sealed record UpdateBrandCommandRequest(int Id, string Name) : IRequest<Results<Created, NotFound<string>>>;
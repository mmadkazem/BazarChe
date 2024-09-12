namespace src.Features.CatalogBrand.UseCase.Commands.CreateBrand;

public sealed record CreateBrandCommandRequest(string Name) : IRequest<Results<Created, BadRequest<string>>>;
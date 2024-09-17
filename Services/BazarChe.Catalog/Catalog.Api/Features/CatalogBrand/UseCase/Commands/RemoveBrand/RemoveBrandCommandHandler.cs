namespace Catalog.Api.Features.CatalogBrand.UseCase.Commands.RemoveBrand;

public sealed class RemoveBrandCommandHandler(IUnitOfWork uow) : IRequestHandler<RemoveBrandCommandRequest, Results<NoContent, NotFound<string>>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Results<NoContent, NotFound<string>>> Handle(RemoveBrandCommandRequest request, CancellationToken token)
    {
        var brand = await _uow.Brands.FirstOrDefaultAsync(x => x.Id == request.Id, token);
        if (brand is null)
        {
            return TypedResults.NotFound($"Brand with id {request.Id} not found.");
        }

        _uow.Brands.Remove(brand);
        await _uow.SaveChangesAsync(token);
        return TypedResults.NoContent();
    }
}
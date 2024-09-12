namespace src.Features.CatalogBrand.UseCase.Commands.UpdateBrand;

public sealed class UpdateBrandCommandHandler(IUnitOfWork uow) : IRequestHandler<UpdateBrandCommandRequest, Results<Created, NotFound<string>>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Results<Created, NotFound<string>>> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
    {
        var brand = await _uow.Brands.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);
        if (brand is null)
        {
            return TypedResults.NotFound($"Brand with id {request.Id} not found.");
        }

        brand.Update(request.Name);
        await _uow.SaveChangesAsync(cancellationToken);

        return TypedResults.Created($"/catalog/api/v1/brands/{brand.Id}");
    }
}
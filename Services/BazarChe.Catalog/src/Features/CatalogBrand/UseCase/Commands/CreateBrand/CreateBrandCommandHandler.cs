namespace src.Features.CatalogBrand.UseCase.Commands.CreateBrand;

public sealed class CreateBrandCommandHandler(IUnitOfWork uow) : IRequestHandler<CreateBrandCommandRequest, Results<Created, BadRequest<string>>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Results<Created, BadRequest<string>>> Handle(CreateBrandCommandRequest request, CancellationToken token)
    {
        var hasBrand = await _uow.Brands.AnyAsync(x => x.Name == request.Name, token);
        if (hasBrand)
        {
            return TypedResults.BadRequest($"A brand with the name '{request.Name}' already exists.");
        }

        var brand = Brand.Create(request.Name);

        _uow.Brands.Add(brand);
        await _uow.SaveChangesAsync(token);

        return TypedResults.Created($"/catalog/api/v1/brands/{brand.Id}");
    }
}
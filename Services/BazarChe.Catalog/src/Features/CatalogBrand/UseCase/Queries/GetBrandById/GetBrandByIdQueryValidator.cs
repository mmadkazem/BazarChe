namespace src.Features.CatalogBrand.UseCase.Queries.GetBrandById;

public sealed class GetBrandByIdQueryValidator : AbstractValidator<GetBrandByIdQueryRequest>
{
    public GetBrandByIdQueryValidator()
    {
        RuleFor(r => r.Id)
            .Must(i => i>0).WithMessage("Id is not valid.");
    }
}
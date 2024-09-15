namespace Catalog.Api.Features.CatalogBrand.UseCase.Commands.RemoveBrand;

public sealed class RemoveBrandCommandValidator : AbstractValidator<RemoveBrandCommandRequest>
{
    public RemoveBrandCommandValidator()
    {
        RuleFor(r => r.Id)
            .Must(i => i > 0).WithMessage("Id is not valid.");
    }
}
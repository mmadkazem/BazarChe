namespace Catalog.Api.Features.CatalogItem.UseCase.Commands.UpdateMaxStockThreshold;

public sealed class UpdateCatalogItemMaxStockThresholdCommandValidator : AbstractValidator<UpdateCatalogItemMaxStockThresholdCommandRequest>
{
    public UpdateCatalogItemMaxStockThresholdCommandValidator()
    {
        RuleFor(x => x.MaxStockThreshold)
            .GreaterThan(0).WithMessage("max stock Threshold invalid");

        RuleFor(x => x.Slug)
            .MaximumLength(150)
            .NotNull().WithMessage("slug invalid");
    }
}

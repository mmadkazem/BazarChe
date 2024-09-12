namespace src.Features.CatalogItem.UseCase.Commands.CreateItem;

public sealed class CreateItemCommandValidator : AbstractValidator<CreateItemCommandRequest>
{
    public CreateItemCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The Catalog item name must not be empty")
            .NotNull().WithMessage("The Catalog item name must not be null")
            .MaximumLength(100).WithMessage("Name should not be more than 100 characters");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("The Catalog item description must not be empty")
            .NotNull().WithMessage("The Catalog item description must not be null")
            .MaximumLength(5000).WithMessage("description should not be more than 500 characters");

        RuleFor(x => x.CatalogId)
            .NotNull().WithMessage("The Catalog item CatalogId must not be null");

        RuleFor(x => x.BrandId)
            .NotNull().WithMessage("The Catalog item BrandId must not be null");

        RuleFor(x => x.MaxStockThreshold)
            .GreaterThan(0).WithMessage("This max stock threshold invalid");
    }
}
namespace Catalog.Api.Features.CatalogCategory.UseCase.Commands.CreateCatalogCategory;

public sealed class CreateCatalogCategoryRequestCommandValidator : AbstractValidator<CreateCatalogCategoryCommandRequest>
{
    public CreateCatalogCategoryRequestCommandValidator()
    {
        RuleFor(x => x.Category)
            .NotEmpty()
            .NotNull()
            .MaximumLength(100);

        RuleFor(x => x.ParentId)
            .Must(x => !x.HasValue || x.HasValue && x.Value > 0).WithMessage("ParentId, if provided, must be a greater than zero.");
    }
}
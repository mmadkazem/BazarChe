namespace src.Features.CatalogItem.UseCase.Commands.UpdateItem;

public sealed class UpdateItemCommandValidator : AbstractValidator<UpdateItemCommandRequest>
{
    public UpdateItemCommandValidator()
    {
        RuleFor(x => x.Slug)
            .NotEmpty().NotNull().WithMessage("slug Invalid");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("The Catalog item description must not be empty")
            .NotNull().WithMessage("The Catalog item description must not be null")
            .MaximumLength(5000).WithMessage("description should not be more than 500 characters");

        RuleFor(x => x.CategoryId)
            .NotNull().Must(i => i > 0).WithMessage("The Catalog item CatalogId must not be null");

        RuleFor(x => x.BrandId)
            .NotNull().Must(i => i > 0).WithMessage("The Catalog item BrandId must not be null");
    }
}
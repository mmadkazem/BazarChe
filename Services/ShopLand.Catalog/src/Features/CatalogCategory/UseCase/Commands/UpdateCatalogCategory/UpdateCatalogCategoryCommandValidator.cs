namespace src.Features.CatalogCategory.UseCase.Commands.UpdateCatalogCategory;

public sealed class UpdateCatalogCategoryCommandValidator : AbstractValidator<UpdateCatalogCategoryCommandRequest>
{
    public UpdateCatalogCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(100);

        RuleFor(x => x.Id)
            .NotNull();
    }
}


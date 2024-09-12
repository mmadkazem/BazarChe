namespace src.Features.CatalogCategory.UseCase.Commands.RemoveCatalogCategoryById;

public sealed class RemoveCatalogCategoryByIdCommandValidator : AbstractValidator<RemoveCatalogCategoryByIdCommandRequest>
{
    public RemoveCatalogCategoryByIdCommandValidator()
    {
        RuleFor(r => r.Id)
            .Must(r => r > 0).WithMessage("Id is not valid.");
    }
}

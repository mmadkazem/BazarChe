namespace src.Features.CatalogBrand.UseCase.Commands.CreateBrand;

public sealed class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommandRequest>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The brand name must not be empty")
            .NotNull().WithMessage("The brand name must not be null")
            .MaximumLength(100).WithMessage("Name should not be more than 100 characters");
    }
}
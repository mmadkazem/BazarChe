namespace src.Features.CatalogBrand.UseCase.Commands.UpdateBrand;

public sealed class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommandRequest>
{
    public UpdateBrandCommandValidator()
    {
        RuleFor(r => r.Id)
            .Must(i => i > 0).WithMessage("Id is not valid.");

        RuleFor(r => r.Name)
            .NotEmpty().WithMessage("The brand name must not be empty")
            .NotNull().WithMessage("The brand name must not be null")
            .MaximumLength(100).WithMessage("Name should not be more than 100 characters");
    }
}
namespace Catalog.Api.Features.CatalogItem.UseCase.Commands.RemoveItem;

public sealed class RemoveItemCommandValidator : AbstractValidator<RemoveItemCommandRequest>
{
    public RemoveItemCommandValidator()
    {
        RuleFor(r => r.Slug)
            .NotEmpty().NotNull().WithMessage("slug Invalid");
    }
}
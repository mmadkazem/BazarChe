namespace src.Features.CatalogItem.UseCase.Queries.GetItemById;

public sealed class GetItemByIdQueryValidator : AbstractValidator<GetItemByIdQueryRequest>
{
    public GetItemByIdQueryValidator()
    {
        RuleFor(r => r.Slug)
            .NotEmpty().NotNull().WithMessage("slug Invalid");
    }
}
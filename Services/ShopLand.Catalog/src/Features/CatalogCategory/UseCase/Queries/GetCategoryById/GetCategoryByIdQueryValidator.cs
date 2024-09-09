namespace src.Features.CatalogCategory.UseCase.Queries.GetCategoryById;

public sealed class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQueryResponse>
{
    public GetCategoryByIdQueryValidator()
    {
        RuleFor(r => r.Id)
        .Must(r => r > 0).WithMessage("Id is not valid.");
    }
}


namespace src.Features.CatalogCategory.UseCase.Queries.GetCategories;

public sealed class GetCategoriesQueryHandler(IUnitOfWork uow)
    : IRequestHandler<GetCategoriesQueryRequest, Results<Ok<IEnumerable<GetCategoriesQueryResponse>>, NotFound<string>>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Results<Ok<IEnumerable<GetCategoriesQueryResponse>>, NotFound<string>>> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = await _uow.Categories.GetAll();

        if (!responses.Any())
        {
            return TypedResults.NotFound("");
        }

        return TypedResults.Ok(responses);
    }
}
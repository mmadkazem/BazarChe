namespace Catalog.Api.Features.CatalogCategory.UseCase.Queries.GetCategoryById;

public sealed class GetCategoryByIdQueryHandler(IUnitOfWork uow) : IRequestHandler<GetCategoryByIdQueryRequest, Results<Ok<GetCategoryByIdQueryResponse>, NotFound<string>>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Results<Ok<GetCategoryByIdQueryResponse>, NotFound<string>>> Handle(GetCategoryByIdQueryRequest request, CancellationToken token)
    {
        var response = await _uow.Categories.Get(ci => ci.Id == request.Id, token);
        if (response is null)
        {
            return TypedResults.NotFound($"Category with this ID: {request.Id} was not found");
        }

        return TypedResults.Ok(response);
    }
}
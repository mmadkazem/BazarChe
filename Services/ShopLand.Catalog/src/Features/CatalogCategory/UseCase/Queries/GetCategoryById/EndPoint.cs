namespace src.Features.CatalogCategory.UseCase.Queries.GetCategoryById;

public sealed class EndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGroup(FeatureManger.Prefix)
            .WithTags(FeatureManger.EndPointTagName)
            .MapGet("{id:int:required}", (ISender _sender, int id, CancellationToken token)
                => _sender.Send(new GetCategoryByIdQueryRequest(id), token));
    }
}
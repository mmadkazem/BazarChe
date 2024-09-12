namespace src.Features.CatalogItem.UseCase.Queries.GetItemById;

public sealed class EndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGroup(FeatureManger.Prefix)
            .WithTags(FeatureManger.EndPointTagName)
            .MapGet("{slug:required}", async (ISender _sender, string slug, CancellationToken token) =>
            {
                return await _sender.Send(new GetItemByIdQueryRequest(slug), token);
            });
    }
}
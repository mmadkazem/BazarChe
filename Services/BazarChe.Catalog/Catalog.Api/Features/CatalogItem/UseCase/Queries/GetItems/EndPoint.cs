namespace Catalog.Api.Features.CatalogItem.UseCase.Queries.GetItems;

public sealed class EndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGroup(FeatureManger.Prefix)
            .WithTags(FeatureManger.EndPointTagName)
            .MapGet("", async (ISender _sender, int page, int sizePage, CancellationToken token) =>
            {
                return await _sender.Send(new GetItemsQueryRequest(page, sizePage), token);
            });
    }
}
namespace Catalog.Api.Features.CatalogItem.UseCase.Commands.UpdateMaxStockThreshold;

public sealed class EndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGroup(FeatureManger.Prefix)
            .WithTags(FeatureManger.EndPointTagName)
            .MapPatch("{slug:required}",
            async (ISender _sender, string slug, int maxStockThreshold, CancellationToken token) =>
            {
                return await _sender.Send(new UpdateCatalogItemMaxStockThresholdCommandRequest(slug, maxStockThreshold), token);
            });
    }
}
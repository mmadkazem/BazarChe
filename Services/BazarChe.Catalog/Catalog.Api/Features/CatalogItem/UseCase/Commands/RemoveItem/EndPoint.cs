namespace Catalog.Api.Features.CatalogItem.UseCase.Commands.RemoveItem;

public sealed class EndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGroup(FeatureManger.Prefix)
            .WithTags(FeatureManger.EndPointTagName)
            .MapDelete("{slug:required}", async (ISender _sender, string slug, CancellationToken token) =>
            {
                return await _sender.Send(new RemoveItemCommandRequest(slug), token);
            });
    }
}
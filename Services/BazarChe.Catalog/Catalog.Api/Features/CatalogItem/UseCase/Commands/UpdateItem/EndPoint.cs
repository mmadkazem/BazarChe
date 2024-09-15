namespace Catalog.Api.Features.CatalogItem.UseCase.Commands.UpdateItem;

public sealed class EndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGroup(FeatureManger.Prefix)
            .WithTags(FeatureManger.EndPointTagName)
            .MapPut("{slug:required}", async (ISender _sender, string slug, UpdateItemDTO model, CancellationToken token) =>
            {
                var request = UpdateItemCommandRequest.Create(slug, model);
                return await _sender.Send(request, token);
            });
    }
}
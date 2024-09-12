namespace src.Features.CatalogItem.UseCase.Commands.CreateItem;

public sealed class EndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGroup(FeatureManger.Prefix)
            .WithTags(FeatureManger.EndPointTagName)
            .MapPost("", async (ISender _sender, CreateItemCommandRequest request, CancellationToken token) =>
            {
                return await _sender.Send(request, token);
            });
    }
}
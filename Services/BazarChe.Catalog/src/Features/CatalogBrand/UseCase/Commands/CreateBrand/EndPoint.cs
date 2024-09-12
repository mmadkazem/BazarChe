namespace src.Features.CatalogBrand.UseCase.Commands.CreateBrand;

public sealed class EndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGroup(FeatureManger.Prefix)
            .WithTags(FeatureManger.EndPointTagName)
            .MapPost("", async (ISender _sender, CreateBrandCommandRequest request, CancellationToken token) =>
            {
                return await _sender.Send(request, token);
            });
    }
}
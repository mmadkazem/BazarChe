namespace Catalog.Api.Features.CatalogBrand.UseCase.Commands.RemoveBrand;

public sealed class EndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGroup(FeatureManger.Prefix)
            .WithTags(FeatureManger.EndPointTagName)
            .MapDelete("{id:int:required}", async (ISender _sender, int id, CancellationToken token) =>
            {
                return await _sender.Send(new RemoveBrandCommandRequest(id), token);
            });
    }
}
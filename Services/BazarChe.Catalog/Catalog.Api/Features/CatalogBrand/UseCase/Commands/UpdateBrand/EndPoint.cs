using src.Features.CatalogBrand.UseCase.Commands.UpdateBrand;

namespace Catalog.Api.Features.CatalogBrand.UseCase.Commands.UpdateBrand;

public sealed class EndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGroup(FeatureManger.Prefix)
            .WithTags(FeatureManger.EndPointTagName)
            .MapDelete("{id:int:required}", async (ISender _sender, int id, string name, CancellationToken token) =>
            {
                return await _sender.Send(new UpdateBrandCommandRequest(id, name), token);
            });
    }
}
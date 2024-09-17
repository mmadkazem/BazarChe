namespace Catalog.Api.Features.CatalogBrand.UseCase.Queries.GetBrandById;

public sealed class EndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGroup(FeatureManger.Prefix)
            .WithTags(FeatureManger.EndPointTagName)
            .MapGet("{id:int:required}", async (ISender _sender, int id, CancellationToken token) =>
            {
                return await _sender.Send(new GetBrandByIdQueryRequest(id), token);
            });
    }
}

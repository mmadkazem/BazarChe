namespace Catalog.Api.Features.CatalogBrand.UseCase.Queries.GetBrands;

public sealed class EndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGroup(FeatureManger.Prefix)
            .WithTags(FeatureManger.EndPointTagName)
            .MapGet("", async (ISender _sender, CancellationToken token) =>
            {
                return await _sender.Send(new GetBrandsQueryRequest(), token);
            });
    }
}
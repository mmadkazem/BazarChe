namespace src.Features.CatalogCategory.UseCase.Commands.UpdateCatalogCategory;

public sealed class EndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGroup(FeatureManger.Prefix)
            .WithTags(FeatureManger.EndPointTagName)
            .MapPut("", async (ISender _sender, UpdateCatalogCategoryCommandRequest request, CancellationToken token) =>
            {
                return await _sender.Send(request, token);
            });
    }
}
namespace src.Features.CatalogCategory.UseCase.Commands.CreateCatalogCategory;


public sealed class EndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGroup(FeatureManger.Prefix)
            .WithTags(FeatureManger.EndPointTagName)
            .MapPost("", async (ISender _sender, CreateCatalogCategoryCommandRequest request, CancellationToken token) =>
            {
                return await _sender.Send(request, token);
            });
    }
}
namespace src.Features.CatalogCategory.UseCase.Commands.UpdateCatalogCategory;

public sealed class EndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGroup(FeatureManger.Prefix)
            .WithTags(FeatureManger.EndPointTagName)
            .MapPut("{id:int:required}", async (ISender _sender, int id, string name, CancellationToken token) =>
            {
                return await _sender.Send(new UpdateCatalogCategoryCommandRequest(id, name), token);
            });
    }
}
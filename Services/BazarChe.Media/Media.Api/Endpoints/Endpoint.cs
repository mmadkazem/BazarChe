namespace Media.Api.Endpoints;


public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapUploadCatalogMediaEndpoint();
        app.MapGetImageEndpoint();
    }
}
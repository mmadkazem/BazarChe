namespace Media.Api.Endpoints;

public static class GetImageEndpoint
{
    public static void MapGetImageEndpoint(this WebApplication app)
    {
        app.MapGet("/{token:guid:required}",
            async (MediaDbContext dbContext, MinioClient minio, Guid Token) =>
            {

                var foundToken = await dbContext.Tokens.FirstOrDefaultAsync(x => x.Id == Token && x.ExpireOn <= DateTime.UtcNow);
                if (foundToken is null)
                    return TypedResults.NotFound();

                foundToken.CountAccess++;

                MemoryStream memoryStream = new();

                var getObjectArgs = new GetObjectArgs()
                                            .WithBucket(foundToken.BucketName)
                                            .WithObject(foundToken.ObjectName)
                                            .WithCallbackStream((stream) =>
                                            {
                                                stream.CopyTo(memoryStream);
                                            });

                await minio.GetObjectAsync(getObjectArgs);
                return Results.File(memoryStream.ToArray(), contentType: foundToken.ContentType);
            });
    }
}
namespace Media.Api.Endpoints;


public static class UploadCatalogMediaEndpoint
{
    // TODO: add authentication and authorization and Get Business Bucket in Jwt Payload
    public static void MapUploadCatalogMediaEndpoint(this WebApplication app)
    {
        app.MapPost("/{bucket}/{catalogId}", async (
            string bucket,
            string catalogId,
            IFormFile file,
            IMinioClient minio,
            MediaDbContext dbContext,
            IPublishEndpoint publisher) =>
        {
            var putObjectArgs = new PutObjectArgs()
                                        .WithBucket(bucket)
                                        .WithObject(file.FileName)
                                        .WithContentType(file.ContentType)
                                        .WithStreamData(file.OpenReadStream())
                                        .WithObjectSize(file.Length);

            try
            {
                await minio.PutObjectAsync(putObjectArgs);

                var token = new UrlToken
                {
                    Id = Guid.NewGuid(),
                    BucketName = bucket,
                    ObjectName = file.FileName,
                    ContentType = file.ContentType,
                    ExpireOn = DateTime.UtcNow.AddMinutes(10),
                };

                dbContext.Tokens.Add(token);
                await dbContext.SaveChangesAsync();

                var url = $"{app.Urls.First()}/{token.Id}";

                await publisher.Publish(new MediaUploadedEvent(file.FileName, url, catalogId, DateTime.UtcNow));

                return Results.Ok(token.Id);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
            // remove on production
            // TODO: add Profile Service CSRF Token
        }).DisableAntiforgery();
        }
}
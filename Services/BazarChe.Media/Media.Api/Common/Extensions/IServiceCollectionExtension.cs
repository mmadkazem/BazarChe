namespace Media.Api.Common.Extensions;



public static class IServiceCollectionExtension
{
    public static void AddServiceCollection(this WebApplicationBuilder builder)
    {
        builder.Services.AddAntiforgery(options =>
        {
            options.HeaderName = "X-CSRF-TOKEN";
        });

        builder.Services.AddDbContext<MediaDbContext>(configure =>
        {
            configure.UseInMemoryDatabase(Guid.NewGuid().ToString());
        });

        builder.DbContextConfig();
        builder.MinIoConfigure();
        builder.BrokerConfigure();
    }
    private static void BrokerConfigure(this WebApplicationBuilder builder)
    {
        builder.Services.AddMassTransit(configure =>
        {
            var brokerConfig = BrokerOptionFactory.Create();
            configure.AddConsumers(Assembly.GetExecutingAssembly());
            configure.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(brokerConfig.Host);

                cfg.ConfigureEndpoints(ctx);
            });
        });
    }

    private static void DbContextConfig(this WebApplicationBuilder builder)
    {
        var option = builder.Configuration.GetSection(MongoDbOption.SectionName).Get<MongoDbOption>()!;

        builder.Services.AddDbContext<MediaDbContext>(options =>
        {
            options.UseMongoDB(option.Host, option.DatabaseName);
        });
    }

    private static void MinIoConfigure(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddSingleton(config =>
        {
            var options = builder.Configuration.GetSection(MinIoOption.SectionName).Get<MinIoOption>()!;
            return new MinioClient()
                        .WithEndpoint(options.MinioEndpoint)
                        .WithCredentials(options.AccessKey, options.SecretKey)
                        .Build();
        });
    }
}

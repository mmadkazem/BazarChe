namespace Media.Api.Extensions;



public static class IServiceCollectionExtension
{
    public static void ConfigureService(this WebApplicationBuilder builder)
    {
        builder.Services.AddAntiforgery(options =>
        {
            options.HeaderName = "X-CSRF-TOKEN";
        });

        builder.Services.AddDbContext<MediaDbContext>(configure =>
        {
            configure.UseInMemoryDatabase(Guid.NewGuid().ToString());
        });

        builder.MinIoConfigure();
        builder.BrokerConfigure();
    }
    private static void BrokerConfigure(this WebApplicationBuilder builder)
    {
        builder.Services.AddMassTransit(configure =>
        {
            var brokerConfig = builder.Configuration.GetSection(BrokerOption.SectionName).Get<BrokerOption>()
                ?? throw new ArgumentNullException(nameof(BrokerOption));

            configure.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(brokerConfig.Host, hostConfigure =>
                {
                    hostConfigure.Username(brokerConfig.Username);
                    hostConfigure.Password(brokerConfig.Password);
                });

                cfg.ConfigureEndpoints(context);
            });
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

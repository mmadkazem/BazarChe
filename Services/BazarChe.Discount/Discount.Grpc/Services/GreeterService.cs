using Grpc.Core;
using Discount.Grpc;

namespace Discount.Grpc.Services;

public class GreeterService(ILogger<GreeterService> logger) : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger = logger;

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }
}

namespace src.Features.CatalogBrand.UseCase.CreateBrand;

public sealed record CreateBrandCommandRequest(string? FName, string LName) : IRequest<string>;

public sealed class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommandRequest, string>
{
    public async Task<string> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return request.FName + request.LName;
    }
}


public sealed class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommandRequest>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(u => u.FName)
            .NotEmpty().WithMessage("for test")
            .NotNull().WithMessage("For test");
    }
}
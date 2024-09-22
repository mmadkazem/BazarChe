var builder = WebApplication.CreateBuilder(args);

builder.ConfigureService();

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAntiforgery();

    app.MapEndpoints();

    app.Run();
}

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceCollection();

var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();
    app.UseExceptionHandler();
    app.MapCarter();
    app.Run();
}
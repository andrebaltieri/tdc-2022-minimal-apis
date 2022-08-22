using BaltaStore.Core.UseCases.Students.Create;
using BaltaStore.Data;
using BaltaStore.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BaltaStoreDataContext>(options =>
    options.UseSqlite(
        "DataSource=app.db;Cache=Shared",
        b => b.MigrationsAssembly("BaltaStore.Api")));

builder.Services.AddTransient<IRepository, StudentRepository>();
builder.Services.AddTransient<Handler>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/v1/students", async (Handler handler, Request request) =>
{
    var response = await handler.HandleAsync(request);
    return response.IsValid
        ? Results.Ok(response)
        : Results.BadRequest(response);
});

app.Run();
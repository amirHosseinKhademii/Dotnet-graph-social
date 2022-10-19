using hot_demo.queries;
using hot_demo.repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<BookRepository>()
    .AddGraphQLServer()
    .AddQueryType<BookQuery>();

var app = builder.Build();

app.MapGraphQL();

app.Run();

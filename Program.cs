using hot_demo.queries;
using hot_demo.repositories;
using hot_demo.services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<BookRepository>().AddSingleton<BookService>()
    .AddGraphQLServer()
    .AddQueryType<BookQuery>();

var app = builder.Build();

app.MapGraphQL();

app.Run();

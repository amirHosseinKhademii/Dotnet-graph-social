using hot_demo.mutations;
using hot_demo.queries;
using hot_demo.repositories;
using hot_demo.services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<BookRepository>().AddSingleton<BookService>()
    .AddGraphQLServer()
    .AddQueryType<BookQuery>().AddMutationType<BookMutation>();

var app = builder.Build();

app.MapGraphQL();

app.Run();

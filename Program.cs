using hot_demo.mutations;
using hot_demo.queries;
using hot_demo.repositories;
using hot_demo.services;
using hot_demo.types;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.Configure<MongoDBSetting>(
    builder.Configuration.GetSection("DataBase"));

builder.Services
    .AddSingleton<BookRepository>()
    .AddSingleton<Service>()
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();


var app = builder.Build();

app.MapGraphQL();

app.Run();

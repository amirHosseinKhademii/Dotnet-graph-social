using hot_demo.queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<BookQuery>();

var app = builder.Build();

app.MapGraphQL();

app.Run();


using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInMemorySubscriptions();
builder.Services.AddRedisSubscriptions((sp) =>
    ConnectionMultiplexer.Connect("host:port"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication")),
    };
});


builder.Services.AddAuthorization();

builder.Services.Configure<MongoDBSetting>(
        builder.Configuration.GetSection("DataBase"))
    .AddHttpContextAccessor()
    .AddSingleton<IJwtAuthentication>(new JwtAuthentication("this is my custom Secret key for authentication"))
    .AddSingleton<Service>()
    .AddGraphQLServer()
    .AddAuthorization()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>();


var app = builder.Build();

app.UseAuthentication();

app.UseAuthorization();

app.UseWebSockets();

app.MapGraphQL();

app.Run();

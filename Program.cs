using System.Text;
using hot_demo.interfaces;
using hot_demo.mutations;
using hot_demo.queries;
using hot_demo.repositories;
using hot_demo.services;
using hot_demo.types;
using hot_demo.utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }
).AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("this is my custom Secret key for authentication")),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    }
);

builder.Services.AddAuthorization();

builder.Services.Configure<MongoDBSetting>(
        builder.Configuration.GetSection("DataBase"))
    .AddSingleton<IJwtAuthentication>(new JwtAuthentication("this is my custom Secret key for authentication"))
    .AddSingleton<BookRepository>()
    .AddSingleton<Service>()
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

var app = builder.Build();

app.UseAuthorization();
app.UseAuthentication();

app.MapGraphQL();

app.Run();

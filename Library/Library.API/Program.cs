using AutoMapper;
using IdentityServer.Domain.Models;
using Library.API.AuthorizationInfo;
using Library.Application;
using Library.Domain.Interfaces;
using Library.Persistance.ApplicationDbContext;
using Library.Persistance.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("DataAccessPostgreSqlProvider");

builder.Services.AddDbContext<AppDbContext>(opt =>
                                opt.UseNpgsql(connString));

builder.Services.AddTransient<IAppDbContext, AppDbContext>()
                .AddTransient<IBookRepository, BookRepository>()
                .AddTransient<IGenreRepository, GenreRepository>()
                .AddTransient<IAuthorRepository, AuthorRepository>()
                .AddAutoMapper(typeof(Library.Application.Queries.MapperProfile),
                               typeof(Library.Application.Commands.MapperProfile),
                               typeof(Library.API.MapperProfile));



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Library API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
    c.OperationFilter<AuthorizeCheckOperationFilter>();
});


IConfigurationSection settingsSection = builder.Configuration.GetSection("AppSettings");
AppSettings settings = settingsSection.Get<AppSettings>();

builder.Services
    .AddAuthentication(settings);

    
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
    .AddJsonOptions(option => option.JsonSerializerOptions.WriteIndented = true);

builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Library API V1");

    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

//app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());

app.MapControllers();

app.Run();

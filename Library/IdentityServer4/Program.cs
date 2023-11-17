using IdentityServer;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Models;
using IdentityServer.Services.Data;
using IdentityServer.Services.Models;
using IdentityServer.Services.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("DataAccessPostgreSqlProvider");

builder.Services.AddDbContext<AuthDbContext>(opt =>
                                opt.UseNpgsql(connString));

builder.Services.AddIdentity<AppUser, IdentityRole>(config =>
{
    config.Password.RequiredLength = 4;
    config.Password.RequireDigit = false;
    config.Password.RequireNonAlphanumeric = false;
    config.Password.RequireUppercase = false;
    config.Password.RequireLowercase = false;
}).AddEntityFrameworkStores<AuthDbContext>()
  .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.Cookie.Name = "Library.Identity.Cookie";
    config.LoginPath = "/Auth/Login";
    config.LogoutPath = "/Auth/Logout";
});

builder.Services.AddIdentityServer()
    .AddAspNetIdentity<AppUser>()
    .AddInMemoryApiResources(Configuration.ApiResources)
    .AddInMemoryIdentityResources(Configuration.IdentityResources)
    .AddInMemoryApiScopes(Configuration.ApiScopes)
    .AddInMemoryClients(Configuration.Clients)
    .AddDeveloperSigningCredential();

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IAuthService, AuthService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfigurationSection settingsSection = builder.Configuration.GetSection("AppSettings");
AppSettings settings = settingsSection.Get<AppSettings>();

builder.Services.AddAuthentication();
builder.Services
    .Configure<AppSettings>(settingsSection);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseIdentityServer();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});
app.Run();

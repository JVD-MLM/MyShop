using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyShop.Application;
using MyShop.Application.Profiles;
using MyShop.Domain.Entities.Identity;
using MyShop.Identity;
using MyShop.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

#region Swagger

builder.Services.AddSwaggerGen();

#endregion

#region Application

builder.Services.ConfigureApplicationServices();

#endregion

#region Identity

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<MyShopDbContext>()
    .AddDefaultTokenProviders();

#endregion

#region JWT Authentication

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

#endregion

#region Context

builder.Services.AddDbContext<MyShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

#endregion

#region CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

#endregion

#region Mapper

var loggerFactory = LoggerFactory.Create(cfg => cfg.AddConsole());

var mapperConfig = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }, loggerFactory);

var mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

#endregion

var app = builder.Build();

#region RoleSeedData

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    await SeedRoles.Initialize(roleManager, userManager);
}

#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
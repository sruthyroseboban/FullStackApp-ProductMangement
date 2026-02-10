using FullStackApp.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FullStackApp.Application.Users.Commands.RegisterUser;
using FullStackApp.Application.Common.Interfaces;
using FullStackApp.Application.Interfaces;
using FullStackApp.Infrastructure.Repositories;
//using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

// DbContext (MySQL)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("DefaultConnection")
        )
    ));
builder.Services.AddScoped<IApplicationDbContext>(provider =>
    provider.GetRequiredService<AppDbContext>());

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


// MediatR

builder.Services.AddMediatR(typeof(RegisterUserCommand).Assembly);


var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

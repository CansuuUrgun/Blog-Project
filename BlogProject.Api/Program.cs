using BlogProject.Application.Repositories;
using BlogProject.Application.Services;
using BlogProject.Application.Services.Concrete;
using BlogProject.Domain.Entities;
using BlogProject.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddScoped<IRepository<Post>, InMemoryPostRepository>()
    .AddScoped<IRepository<User>, InMemoryUserRepository>()
    //.AddScoped<IPostService, PostService>()
    .AddScoped<IUserService,UserService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

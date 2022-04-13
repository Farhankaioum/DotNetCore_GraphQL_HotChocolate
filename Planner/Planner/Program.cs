using Microsoft.EntityFrameworkCore;
using Planner.Data;
using Planner.Repositories;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddDbContextFactory<ApplicationDbContext>( options =>
    options.UseInMemoryDatabase("BlogsManagement"));

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();

app.Run();

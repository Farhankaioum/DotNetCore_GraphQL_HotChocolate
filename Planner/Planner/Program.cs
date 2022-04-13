using Microsoft.EntityFrameworkCore;
using Planner.Data;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddDbContextFactory<ApplicationDbContext>( options =>
    options.UseInMemoryDatabase("BlogsManagement"));

app.Run();

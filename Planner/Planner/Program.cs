using Microsoft.EntityFrameworkCore;
using Planner.Data;
using Planner.GraphQL;
using Planner.Repositories;
using Planner.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<ApplicationDbContext>( options =>
    options.UseInMemoryDatabase("BlogsManagement"));

builder.Services.AddInMemorySubscriptions();

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();

builder.Services
        .AddGraphQLServer()
        .AddType<AuthorType>()
        .AddType<BlogPostType>()
        .AddQueryType<Query>()
        .AddMutationType<Mutation>()
        .AddSubscriptionType<Subscription>();

var app = builder.Build();

app.UseRouting()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapGraphQL();
    });

app.Run();

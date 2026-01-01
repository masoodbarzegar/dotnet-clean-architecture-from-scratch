using Microsoft.EntityFrameworkCore;
using ProjectManagement.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data Source=projectmanagement.db");
});

var app = builder.Build();

app.MapGet("/projects", async (AppDbContext db) =>
{
    var projects = await db.Projects.ToListAsync();
    return Results.Ok(projects);
});

app.Run();
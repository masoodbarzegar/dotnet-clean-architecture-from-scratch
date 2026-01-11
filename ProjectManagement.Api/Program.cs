using FastEndpoints;
using FastEndpoints.Swagger;
using ProjectManagement.Application;
using ProjectManagement.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// ---------- Services ----------
builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument(o =>
{
    o.DocumentSettings = s =>
    {
        s.Title = "Project Management API";
        s.Version = "v1";
    };
});

// Application & Infrastructure
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// ---------- Middleware ----------
app.UseFastEndpoints();
app.UseSwaggerGen();

app.Run();
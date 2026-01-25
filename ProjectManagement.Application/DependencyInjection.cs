using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Application.CreateProject;
using ProjectManagement.Application.GetProjects;

namespace ProjectManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<GetProjectsHandler>();
        services.AddScoped<CreateProjectHandler>();
        return services;
    }
}
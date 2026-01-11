using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Application.GetProjects;

namespace ProjectManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<GetProjectsHandler>();
        return services;
    }
}
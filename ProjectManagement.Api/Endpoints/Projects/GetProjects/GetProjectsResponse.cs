using ProjectManagement.Application;
using ProjectManagement.Application.GetProjects;

namespace ProjectManagement.Api.Endpoints.Projects.GetProjects;

public class GetProjectsResponse
{
    public IReadOnlyList<ProjectListItemDto> Items { get; init; } = [];
}
namespace ProjectManagement.Api.Endpoints.Projects.GetProjects;

public class GetProjectsRequest
{
    public int Page { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
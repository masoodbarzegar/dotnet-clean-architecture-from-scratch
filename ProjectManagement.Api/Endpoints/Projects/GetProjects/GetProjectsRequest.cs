namespace ProjectManagement.Api.Endpoints.Projects.GetProjects;

public class GetProjectsRequest
{
    public int Page { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    public string? Search { get; init; }
    public string? SortBy { get; init; } = "id";
    public string? Order { get; init; } = "asc";
}
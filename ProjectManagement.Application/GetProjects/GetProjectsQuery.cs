namespace ProjectManagement.Application.GetProjects;

public class GetProjectsQuery
{
    public int Page { get; init; } = 1;
    public int PageSize { get; init; } = 20;
    public string? Search { get; init; }
    public string? Status { get; init; }
    public string SortBy { get; init; } = "id";
    public string Order { get; init; } = "asc";
}

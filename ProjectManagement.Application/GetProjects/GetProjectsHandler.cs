using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Application.GetProjects;

public class GetProjectsHandler
{
    private readonly IProjectRepository _repository;
    public GetProjectsHandler(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<(IReadOnlyList<ProjectListItemDto> Items, int TotalCount)> 
        Handle(GetProjectsQuery query, CancellationToken ct)
    {
        var (projects, total) = await _repository.GetPageAsync(
            query.Page,
            query.PageSize,
            query.Search,
            query.SortBy,
            query.Order,
            ct
        );

        var items = projects
            .Select(ProjectPresentationPolicy.ToListItem)
            .ToList();

        return (items, total);

    }
}


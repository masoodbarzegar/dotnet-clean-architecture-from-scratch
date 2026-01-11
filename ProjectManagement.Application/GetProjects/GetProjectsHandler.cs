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
        var total = await _repository.CountAsync(ct);

        var projects = await _repository.GetPageAsync(
             page: query.Page,
             pageSize: query.PageSize,
             ct: ct
        );

        var items = projects
            .Select(ProjectPresentationPolicy.ToListItem)
            .ToList();

        return (items, total);

    }
}


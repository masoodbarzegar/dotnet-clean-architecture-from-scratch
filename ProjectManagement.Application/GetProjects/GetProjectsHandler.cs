using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Application.Projects.GetProjects;

public class GetProjectsHandler
{
    private readonly IProjectRepository _repository;
    public GetProjectsHandler(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProjectListItemDto>> Handle(GetProjectsQuery query)
    {
        Validate(query);

        var projects = await _repository.GetAllAsync();

        return projects
            .Select(ProjectPresentationPolicy.ToListItem)
            .ToList();

    }

    private void Validate(GetProjectsQuery query)
    {
        if (query.Page <= 0)
            throw new ArgumentException("Page must be greater than zero.");

        if (query.PageSize <= 0 || query.PageSize > 100)
            throw new ArgumentException("PageSize must be between 1 and 100.");
    }

}


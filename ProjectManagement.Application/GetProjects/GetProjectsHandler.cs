using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Application.GetProjects;

public class GetProjectsHandler
{
    private readonly IProjectRepository _repository;
    public GetProjectsHandler(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProjectListItemDto>> Handle(GetProjectsQuery query)
    {
        GetProjectsQueryValidator.Validate(query);

        var projects = await _repository.GetAllAsync();

        return projects
            .Select(ProjectPresentationPolicy.ToListItem)
            .ToList();

    }
}


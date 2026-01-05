using ProjectManagement.Domain.Entities;
using ProjectManagement.Application.Projects;

namespace ProjectManagement.Application.Projects.GetProjects;

public class GetProjectsHandler
{
    private readonly IProjectRepository _repository;
    public GetProjectsHandler(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProjectDto>> Handle(GetProjectsQuery query)
    {
        Validate(query);

        var projects = await _repository.GetAllAsync();
        return projects
            .Select(p => new ProjectDto
            {
                Id = p.Id,
                Name = p.Name,
            })
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


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
        var projects = await _repository.GetAllAsync();
        return projects
            .Select(p => new ProjectDto
            {
                Id = p.Id,
                Name = p.Name,
            })
            .ToList();
    }
}


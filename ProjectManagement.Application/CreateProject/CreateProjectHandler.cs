using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Application.CreateProject;

public class CreateProjectHandler
{
    private readonly IProjectRepository _repository;

    public CreateProjectHandler(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<Project> Handle(
        string name,
        CancellationToken ct)
    {
        var project = new Project(name);

        await _repository.AddAsync(project, ct);

        return project;
    }
}
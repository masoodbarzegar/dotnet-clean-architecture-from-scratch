using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Application.Projects;

public interface IProjectRepository
{
    Task<List<Project>> GetAllAsync();
}

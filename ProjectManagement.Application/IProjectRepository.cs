using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Application;

public interface IProjectRepository
{
    Task<List<Project>> GetAllAsync();
}

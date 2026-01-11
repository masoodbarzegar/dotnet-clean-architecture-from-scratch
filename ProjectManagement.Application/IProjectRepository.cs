using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Application;

public interface IProjectRepository
{
    Task<int> CountAsync(CancellationToken ct);

    Task<List<Project>> GetPageAsync(
        int page,
        int pageSize,
        CancellationToken ct);

}

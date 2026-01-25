using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Application;

public interface IProjectRepository
{
    Task<int> CountAsync(CancellationToken ct);

    Task<(List<Project> Items, int TotalCount)> GetPageAsync(
        int page,
        int pageSize,
        string? search,
        string sortBy,
        string order,
        CancellationToken ct);

    Task AddAsync(Project project, CancellationToken ct);


}

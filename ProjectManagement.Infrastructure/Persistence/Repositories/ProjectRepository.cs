using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Infrastructure.Persistence;

namespace ProjectManagement.Infrastructure.Persistence.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly AppDbContext _context;

    public ProjectRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> CountAsync(CancellationToken ct)
    {
        return await _context.Projects.CountAsync(ct);
    }

    public async Task<List<Project>> GetPageAsync(
        int page,
        int pageSize,
        CancellationToken ct)
    {
            var skip = (page - 1) * pageSize;

            return await _context.Projects
                .OrderBy(p => p.Id)          // deterministic paging
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync(ct);
    }
}
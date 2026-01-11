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

    public async Task<(List<Project> Items, int TotalCount)> GetPageAsync(
        int page,
        int pageSize,
        string? search,
        string sortBy,
        string order,
        CancellationToken ct)
    {
        IQueryable<Project> q = _context.Projects;
       
        if (!string.IsNullOrWhiteSpace(search))
            q = q.Where(p => p.Name.Contains(search));

        q = (sortBy, order) switch
        {
            ("name", "desc") => q.OrderByDescending(p => p.Name),
            ("name", _) => q.OrderBy(p => p.Name),

            ("createdAt", "desc") => q.OrderByDescending(p => p.CreatedAt),
            ("createdAt", _) => q.OrderBy(p => p.CreatedAt),

            ("id", "desc") => q.OrderByDescending(p => p.Id),
            _ => q.OrderBy(p => p.Id),
        };

        var total = await q.CountAsync(ct);

        var skip = (page - 1) * pageSize;

        var items = await q
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync(ct);

        return (items, total);
    }
}
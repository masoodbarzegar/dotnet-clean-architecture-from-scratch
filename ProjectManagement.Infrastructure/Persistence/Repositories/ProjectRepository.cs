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

    public async Task<List<Project>> GetAllAsync(CancellationToken ct)
    {
        return await _context.Projects.ToListAsync(ct);
    }
}
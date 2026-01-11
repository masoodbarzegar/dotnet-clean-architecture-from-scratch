using Microsoft.EntityFrameworkCore;
using ProjectManagement.Infrastructure.Persistence.Seed;

namespace ProjectManagement.Infrastructure.Persistence;

public static class AppDbContextSeed
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (await context.Projects.AnyAsync())
            return;

        context.Projects.AddRange(ProjectSeed.GetProjects());
        await context.SaveChangesAsync();
    }
}
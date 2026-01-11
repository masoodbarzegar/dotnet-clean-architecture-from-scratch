using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Infrastructure.Persistence.Seed;

public static class ProjectSeed
{
    public static List<Project> GetProjects()
    {
        return new List<Project>
        {
            new Project("Project Alpha"),
            new Project("Project Beta"),
            new Project("Project Gamma"),
            new Project("Project Delta"),
            new Project("Project Epsilon"),
            new Project("Project Zeta"),
            new Project("Project Eta"),
            new Project("Project Theta")
        };
    }
}
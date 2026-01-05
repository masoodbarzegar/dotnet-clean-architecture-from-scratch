using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Application;

public static class ProjectPresentationPolicy
{
    public static ProjectListItemDto ToListItem(Project project)
    {
        return new ProjectListItemDto
        {
            ProjectId = project.Id.ToString(),
            DisplayName = project.Name.ToUpperInvariant()
        };
    }
}

namespace ProjectManagement.Application.GetProjects;

public static class GetProjectsQueryValidator
{
    public static void Validate(GetProjectsQuery query)
    {
        if (query == null)
            throw new ArgumentNullException(nameof(query));

        if (query.Page <= 0)
            throw new ArgumentException("Page must be greater than zero.");

        if (query.PageSize <= 0 || query.PageSize > 100)
            throw new ArgumentException("PageSize must be between 1 and 100.");
    }
}

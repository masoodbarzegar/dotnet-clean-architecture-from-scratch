using FastEndpoints;
using ProjectManagement.Application;
using ProjectManagement.Application.GetProjects;

namespace ProjectManagement.Api.Endpoints.Projects.GetProjects;

public class GetProjectsEndpoint
    : EndpointWithoutRequest<List<ProjectListItemDto>>
{
    private readonly GetProjectsHandler _handler;

    public GetProjectsEndpoint(GetProjectsHandler handler)
    {
        _handler = handler;
    }

    public override void Configure()
    {
        Get("/projects");
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Get projects";
            s.Description = "Returns list of projects";
        });

    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await _handler.Handle(new GetProjectsQuery());
        Response = result;
    }
}
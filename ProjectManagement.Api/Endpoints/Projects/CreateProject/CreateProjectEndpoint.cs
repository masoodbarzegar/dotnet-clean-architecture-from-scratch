using FastEndpoints;
using ProjectManagement.Application.CreateProject;

namespace ProjectManagement.Api.Endpoints.Projects.CreateProject;

public class CreateProjectEndpoint
    : Endpoint<CreateProjectRequest, CreateProjectResponse>
{
    private readonly CreateProjectHandler _handler;

    public CreateProjectEndpoint(CreateProjectHandler handler)
    {
        _handler = handler;
    }

    public override void Configure()
    {
        Post("/projects");
        AllowAnonymous();
    }

    public override async Task HandleAsync(
        CreateProjectRequest req,
        CancellationToken ct)
    {
        var project = await _handler.Handle(req.Name, ct);

        Response = new CreateProjectResponse
        {
            ProjectId = project.Id.ToString(),
            Name = project.Name
        };
    }
}
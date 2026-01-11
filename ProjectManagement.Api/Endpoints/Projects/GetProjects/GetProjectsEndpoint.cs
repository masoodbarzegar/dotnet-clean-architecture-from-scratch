using FastEndpoints;
using ProjectManagement.Application;
using ProjectManagement.Application.GetProjects;

namespace ProjectManagement.Api.Endpoints.Projects.GetProjects;

public class GetProjectsEndpoint
    : Endpoint<GetProjectsRequest, GetProjectsResponse>
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

    public override async Task HandleAsync(
         GetProjectsRequest req,
         CancellationToken ct)
    {
        // Mapping: Request → Query
        var query = new GetProjectsQuery
        {
            Page = req.Page,
            PageSize = req.PageSize,
            Search = req.Search,
            SortBy = req.SortBy ?? "id",
            Order = req.Order ?? "asc"
        };

        var (items, total) = await _handler.Handle(query, ct);

        Response = new GetProjectsResponse
        {
            Items = items,
            TotalCount = total,
            Page = req.Page,
            PageSize = req.PageSize
        };
    }
}
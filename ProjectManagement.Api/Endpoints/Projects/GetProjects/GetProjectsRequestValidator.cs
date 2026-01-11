using FastEndpoints;
using FluentValidation;

namespace ProjectManagement.Api.Endpoints.Projects.GetProjects;

public class GetProjectsRequestValidator : Validator<GetProjectsRequest>
{
    public GetProjectsRequestValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(1);

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 50);
    }
}
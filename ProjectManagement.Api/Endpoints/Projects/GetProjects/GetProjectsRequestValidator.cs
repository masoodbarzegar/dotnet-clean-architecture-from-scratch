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

        RuleFor(x => x.Order)
            .Must(x => x is null or "asc" or "desc")
            .WithMessage("order must be 'asc' or 'desc'");

        RuleFor(x => x.SortBy)
            .Must(x => x is null or "id" or "name" or "createdAt")
            .WithMessage("sortBy must be one of: id, name, createdAt");
    }
}
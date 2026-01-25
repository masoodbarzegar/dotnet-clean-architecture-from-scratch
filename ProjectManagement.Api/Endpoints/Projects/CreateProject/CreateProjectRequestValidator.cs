using FastEndpoints;
using FluentValidation;

namespace ProjectManagement.Api.Endpoints.Projects.CreateProject;

public class CreateProjectRequestValidator
    : Validator<CreateProjectRequest>
{
    public CreateProjectRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3);
    }
}
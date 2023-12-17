using FluentValidation;

namespace Application.Features.EstateAgents.Commands.Update;

public class UpdateEstateAgentCommandValidator : AbstractValidator<UpdateEstateAgentCommand>
{
    public UpdateEstateAgentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AgentName).NotEmpty();
        RuleFor(c => c.AuthorizedName).NotEmpty();
        RuleFor(c => c.AuthorizedSurname).NotEmpty();
        RuleFor(c => c.AuthorizedSecondSurname).NotEmpty();
        RuleFor(c => c.AuthorizedSecondName).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.City).NotEmpty();
        RuleFor(c => c.District).NotEmpty();
        RuleFor(c => c.PostalCode).NotEmpty();
        RuleFor(c => c.Phone).NotEmpty();
        RuleFor(c => c.Fax).NotEmpty();
        RuleFor(c => c.EmployeeCount).NotEmpty();
    }
}
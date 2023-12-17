using FluentValidation;

namespace Application.Features.EstateAgents.Commands.Delete;

public class DeleteEstateAgentCommandValidator : AbstractValidator<DeleteEstateAgentCommand>
{
    public DeleteEstateAgentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
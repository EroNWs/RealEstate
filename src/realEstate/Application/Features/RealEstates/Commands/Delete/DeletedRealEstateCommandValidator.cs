using FluentValidation;

namespace Application.Features.RealEstates.Commands.Delete;

public class DeleteRealEstateCommandValidator : AbstractValidator<DeleteRealEstateCommand>
{
    public DeleteRealEstateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
using FluentValidation;

namespace Application.Features.RealEstates.Commands.Update;

public class UpdateRealEstateCommandValidator : AbstractValidator<UpdateRealEstateCommand>
{
    public UpdateRealEstateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Type).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.SquareMeters).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.City).NotEmpty();
        RuleFor(c => c.District).NotEmpty();
        RuleFor(c => c.TransactionId).NotEmpty();
        RuleFor(c => c.TransactionType).NotEmpty();
    }
}
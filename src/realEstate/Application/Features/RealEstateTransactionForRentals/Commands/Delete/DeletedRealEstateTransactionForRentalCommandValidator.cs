using FluentValidation;

namespace Application.Features.RealEstateTransactionForRentals.Commands.Delete;

public class DeleteRealEstateTransactionForRentalCommandValidator : AbstractValidator<DeleteRealEstateTransactionForRentalCommand>
{
    public DeleteRealEstateTransactionForRentalCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
using FluentValidation;

namespace Application.Features.RealEstateTransactionForRentals.Commands.Create;

public class CreateRealEstateTransactionForRentalCommandValidator : AbstractValidator<CreateRealEstateTransactionForRentalCommand>
{
    public CreateRealEstateTransactionForRentalCommandValidator()
    {
        RuleFor(c => c.RealEstateId).NotEmpty();
        RuleFor(c => c.RealEstate).NotEmpty();
        RuleFor(c => c.EtateAgentId).NotEmpty();
        RuleFor(c => c.EstateAgent).NotEmpty();
        RuleFor(c => c.TenantId).NotEmpty();
        RuleFor(c => c.Tenant).NotEmpty();
        RuleFor(c => c.RenterId).NotEmpty();
        RuleFor(c => c.Renter).NotEmpty();
    }
}
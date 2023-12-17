using FluentValidation;

namespace Application.Features.RealEstateTransactionForSales.Commands.Create;

public class CreateRealEstateTransactionForSaleCommandValidator : AbstractValidator<CreateRealEstateTransactionForSaleCommand>
{
    public CreateRealEstateTransactionForSaleCommandValidator()
    {
        RuleFor(c => c.RealEstateId).NotEmpty();
        RuleFor(c => c.RealEstate).NotEmpty();
        RuleFor(c => c.EstateAgentId).NotEmpty();
        RuleFor(c => c.EstateAgent).NotEmpty();
        RuleFor(c => c.BuyerId).NotEmpty();
        RuleFor(c => c.Buyer).NotEmpty();
        RuleFor(c => c.SellerId).NotEmpty();
        RuleFor(c => c.Seller).NotEmpty();
    }
}
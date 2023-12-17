using FluentValidation;

namespace Application.Features.RealEstateTransactionForSales.Commands.Update;

public class UpdateRealEstateTransactionForSaleCommandValidator : AbstractValidator<UpdateRealEstateTransactionForSaleCommand>
{
    public UpdateRealEstateTransactionForSaleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
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
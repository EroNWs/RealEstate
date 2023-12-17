using FluentValidation;

namespace Application.Features.RealEstateTransactionForSales.Commands.Delete;

public class DeleteRealEstateTransactionForSaleCommandValidator : AbstractValidator<DeleteRealEstateTransactionForSaleCommand>
{
    public DeleteRealEstateTransactionForSaleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
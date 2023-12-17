using FluentValidation;

namespace Application.Features.Customers.Commands.Update;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CustomerName).NotEmpty();
        RuleFor(c => c.CustomerSurName).NotEmpty();
        RuleFor(c => c.CustomerSecondSurname).NotEmpty();
        RuleFor(c => c.CustomerSecondName).NotEmpty();
        RuleFor(c => c.BirthDate).NotEmpty();
        RuleFor(c => c.Gender).NotEmpty();
        RuleFor(c => c.Occupatipon).NotEmpty();
        RuleFor(c => c.MaritalStatus).NotEmpty();
        RuleFor(c => c.HomePhone).NotEmpty();
        RuleFor(c => c.MobilePhone).NotEmpty();
        RuleFor(c => c.NumberOfChildren).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.SpouseOccupation).NotEmpty();
        RuleFor(c => c.SpouseBirthDate).NotEmpty();
        RuleFor(c => c.IsBuyerCustomer).NotEmpty();
        RuleFor(c => c.IsSellerCustomer).NotEmpty();
        RuleFor(c => c.IsTenantCustomer).NotEmpty();
        RuleFor(c => c.IsRenterCustomer).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.City).NotEmpty();
        RuleFor(c => c.District).NotEmpty();
        RuleFor(c => c.EstateAgentId).NotEmpty();
        RuleFor(c => c.EstateAgent).NotEmpty();
    }
}
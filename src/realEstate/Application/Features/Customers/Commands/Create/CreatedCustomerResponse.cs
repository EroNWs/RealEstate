using Core.Application.Responses;
using Domain.Entities;
using Domain.Enums;
using Domain.Enums;
using Domain.Enums;
using Domain.Enums;

namespace Application.Features.Customers.Commands.Create;

public class CreatedCustomerResponse : IResponse
{
    public Guid Id { get; set; }
    public string CustomerName { get; set; }
    public string CustomerSurName { get; set; }
    public string? CustomerSecondSurname { get; set; }
    public string? CustomerSecondName { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public Occupation Occupatipon { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    public string HomePhone { get; set; }
    public string MobilePhone { get; set; }
    public byte NumberOfChildren { get; set; }
    public string Email { get; set; }
    public Occupation SpouseOccupation { get; set; }
    public DateTime SpouseBirthDate { get; set; }
    public bool IsBuyerCustomer { get; set; }
    public bool IsSellerCustomer { get; set; }
    public bool IsTenantCustomer { get; set; }
    public bool IsRenterCustomer { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public Guid EstateAgentId { get; set; }
    public EstateAgent EstateAgent { get; set; }
}
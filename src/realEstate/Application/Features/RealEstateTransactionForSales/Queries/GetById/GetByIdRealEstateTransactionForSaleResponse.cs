using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.RealEstateTransactionForSales.Queries.GetById;

public class GetByIdRealEstateTransactionForSaleResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid RealEstateId { get; set; }
    public RealEstate RealEstate { get; set; }
    public Guid EstateAgentId { get; set; }
    public EstateAgent EstateAgent { get; set; }
    public Guid BuyerId { get; set; }
    public Customer Buyer { get; set; }
    public Guid SellerId { get; set; }
    public Customer Seller { get; set; }
}
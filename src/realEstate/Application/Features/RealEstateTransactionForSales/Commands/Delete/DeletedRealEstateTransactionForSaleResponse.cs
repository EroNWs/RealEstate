using Core.Application.Responses;

namespace Application.Features.RealEstateTransactionForSales.Commands.Delete;

public class DeletedRealEstateTransactionForSaleResponse : IResponse
{
    public Guid Id { get; set; }
}
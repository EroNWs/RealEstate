using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRealEstateTransactionForSaleRepository : IAsyncRepository<RealEstateTransactionForSale, Guid>, IRepository<RealEstateTransactionForSale, Guid>
{
}
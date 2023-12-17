using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RealEstateTransactionForSaleRepository : EfRepositoryBase<RealEstateTransactionForSale, Guid, BaseDbContext>, IRealEstateTransactionForSaleRepository
{
    public RealEstateTransactionForSaleRepository(BaseDbContext context) : base(context)
    {
    }
}
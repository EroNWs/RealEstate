using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRealEstateTransactionForRentalRepository : IAsyncRepository<RealEstateTransactionForRental, Guid>, IRepository<RealEstateTransactionForRental, Guid>
{
}
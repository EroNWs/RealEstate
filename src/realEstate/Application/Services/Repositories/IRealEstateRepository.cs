using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRealEstateRepository : IAsyncRepository<RealEstate, Guid>, IRepository<RealEstate, Guid>
{
}
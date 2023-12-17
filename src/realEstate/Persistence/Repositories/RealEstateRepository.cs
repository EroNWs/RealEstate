using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RealEstateRepository : EfRepositoryBase<RealEstate, Guid, BaseDbContext>, IRealEstateRepository
{
    public RealEstateRepository(BaseDbContext context) : base(context)
    {
    }
}
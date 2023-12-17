using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class EstateAgentRepository : EfRepositoryBase<EstateAgent, Guid, BaseDbContext>, IEstateAgentRepository
{
    public EstateAgentRepository(BaseDbContext context) : base(context)
    {
    }
}
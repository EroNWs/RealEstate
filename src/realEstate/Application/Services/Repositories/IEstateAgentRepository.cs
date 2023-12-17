using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IEstateAgentRepository : IAsyncRepository<EstateAgent, Guid>, IRepository<EstateAgent, Guid>
{
}
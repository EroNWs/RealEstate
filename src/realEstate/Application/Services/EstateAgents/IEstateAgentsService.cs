using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.EstateAgents;

public interface IEstateAgentsService
{
    Task<EstateAgent?> GetAsync(
        Expression<Func<EstateAgent, bool>> predicate,
        Func<IQueryable<EstateAgent>, IIncludableQueryable<EstateAgent, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<EstateAgent>?> GetListAsync(
        Expression<Func<EstateAgent, bool>>? predicate = null,
        Func<IQueryable<EstateAgent>, IOrderedQueryable<EstateAgent>>? orderBy = null,
        Func<IQueryable<EstateAgent>, IIncludableQueryable<EstateAgent, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<EstateAgent> AddAsync(EstateAgent estateAgent);
    Task<EstateAgent> UpdateAsync(EstateAgent estateAgent);
    Task<EstateAgent> DeleteAsync(EstateAgent estateAgent, bool permanent = false);
}

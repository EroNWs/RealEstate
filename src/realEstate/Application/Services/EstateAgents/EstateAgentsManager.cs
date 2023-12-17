using Application.Features.EstateAgents.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.EstateAgents;

public class EstateAgentsManager : IEstateAgentsService
{
    private readonly IEstateAgentRepository _estateAgentRepository;
    private readonly EstateAgentBusinessRules _estateAgentBusinessRules;

    public EstateAgentsManager(IEstateAgentRepository estateAgentRepository, EstateAgentBusinessRules estateAgentBusinessRules)
    {
        _estateAgentRepository = estateAgentRepository;
        _estateAgentBusinessRules = estateAgentBusinessRules;
    }

    public async Task<EstateAgent?> GetAsync(
        Expression<Func<EstateAgent, bool>> predicate,
        Func<IQueryable<EstateAgent>, IIncludableQueryable<EstateAgent, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        EstateAgent? estateAgent = await _estateAgentRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return estateAgent;
    }

    public async Task<IPaginate<EstateAgent>?> GetListAsync(
        Expression<Func<EstateAgent, bool>>? predicate = null,
        Func<IQueryable<EstateAgent>, IOrderedQueryable<EstateAgent>>? orderBy = null,
        Func<IQueryable<EstateAgent>, IIncludableQueryable<EstateAgent, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<EstateAgent> estateAgentList = await _estateAgentRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return estateAgentList;
    }

    public async Task<EstateAgent> AddAsync(EstateAgent estateAgent)
    {
        EstateAgent addedEstateAgent = await _estateAgentRepository.AddAsync(estateAgent);

        return addedEstateAgent;
    }

    public async Task<EstateAgent> UpdateAsync(EstateAgent estateAgent)
    {
        EstateAgent updatedEstateAgent = await _estateAgentRepository.UpdateAsync(estateAgent);

        return updatedEstateAgent;
    }

    public async Task<EstateAgent> DeleteAsync(EstateAgent estateAgent, bool permanent = false)
    {
        EstateAgent deletedEstateAgent = await _estateAgentRepository.DeleteAsync(estateAgent);

        return deletedEstateAgent;
    }
}

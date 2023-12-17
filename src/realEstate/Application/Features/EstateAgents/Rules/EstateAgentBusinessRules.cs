using Application.Features.EstateAgents.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.EstateAgents.Rules;

public class EstateAgentBusinessRules : BaseBusinessRules
{
    private readonly IEstateAgentRepository _estateAgentRepository;

    public EstateAgentBusinessRules(IEstateAgentRepository estateAgentRepository)
    {
        _estateAgentRepository = estateAgentRepository;
    }

    public Task EstateAgentShouldExistWhenSelected(EstateAgent? estateAgent)
    {
        if (estateAgent == null)
            throw new BusinessException(EstateAgentsBusinessMessages.EstateAgentNotExists);
        return Task.CompletedTask;
    }

    public async Task EstateAgentIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        EstateAgent? estateAgent = await _estateAgentRepository.GetAsync(
            predicate: ea => ea.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await EstateAgentShouldExistWhenSelected(estateAgent);
    }
}
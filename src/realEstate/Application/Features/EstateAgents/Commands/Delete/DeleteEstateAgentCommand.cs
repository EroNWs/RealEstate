using Application.Features.EstateAgents.Constants;
using Application.Features.EstateAgents.Constants;
using Application.Features.EstateAgents.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.EstateAgents.Constants.EstateAgentsOperationClaims;

namespace Application.Features.EstateAgents.Commands.Delete;

public class DeleteEstateAgentCommand : IRequest<DeletedEstateAgentResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, EstateAgentsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetEstateAgents";

    public class DeleteEstateAgentCommandHandler : IRequestHandler<DeleteEstateAgentCommand, DeletedEstateAgentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEstateAgentRepository _estateAgentRepository;
        private readonly EstateAgentBusinessRules _estateAgentBusinessRules;

        public DeleteEstateAgentCommandHandler(IMapper mapper, IEstateAgentRepository estateAgentRepository,
                                         EstateAgentBusinessRules estateAgentBusinessRules)
        {
            _mapper = mapper;
            _estateAgentRepository = estateAgentRepository;
            _estateAgentBusinessRules = estateAgentBusinessRules;
        }

        public async Task<DeletedEstateAgentResponse> Handle(DeleteEstateAgentCommand request, CancellationToken cancellationToken)
        {
            EstateAgent? estateAgent = await _estateAgentRepository.GetAsync(predicate: ea => ea.Id == request.Id, cancellationToken: cancellationToken);
            await _estateAgentBusinessRules.EstateAgentShouldExistWhenSelected(estateAgent);

            await _estateAgentRepository.DeleteAsync(estateAgent!);

            DeletedEstateAgentResponse response = _mapper.Map<DeletedEstateAgentResponse>(estateAgent);
            return response;
        }
    }
}
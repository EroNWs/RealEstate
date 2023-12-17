using Application.Features.EstateAgents.Constants;
using Application.Features.EstateAgents.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.EstateAgents.Constants.EstateAgentsOperationClaims;

namespace Application.Features.EstateAgents.Queries.GetById;

public class GetByIdEstateAgentQuery : IRequest<GetByIdEstateAgentResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdEstateAgentQueryHandler : IRequestHandler<GetByIdEstateAgentQuery, GetByIdEstateAgentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEstateAgentRepository _estateAgentRepository;
        private readonly EstateAgentBusinessRules _estateAgentBusinessRules;

        public GetByIdEstateAgentQueryHandler(IMapper mapper, IEstateAgentRepository estateAgentRepository, EstateAgentBusinessRules estateAgentBusinessRules)
        {
            _mapper = mapper;
            _estateAgentRepository = estateAgentRepository;
            _estateAgentBusinessRules = estateAgentBusinessRules;
        }

        public async Task<GetByIdEstateAgentResponse> Handle(GetByIdEstateAgentQuery request, CancellationToken cancellationToken)
        {
            EstateAgent? estateAgent = await _estateAgentRepository.GetAsync(predicate: ea => ea.Id == request.Id, cancellationToken: cancellationToken);
            await _estateAgentBusinessRules.EstateAgentShouldExistWhenSelected(estateAgent);

            GetByIdEstateAgentResponse response = _mapper.Map<GetByIdEstateAgentResponse>(estateAgent);
            return response;
        }
    }
}
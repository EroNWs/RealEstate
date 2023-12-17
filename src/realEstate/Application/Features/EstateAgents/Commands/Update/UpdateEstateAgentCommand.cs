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

namespace Application.Features.EstateAgents.Commands.Update;

public class UpdateEstateAgentCommand : IRequest<UpdatedEstateAgentResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string AgentName { get; set; }
    public string AuthorizedName { get; set; }
    public string AuthorizedSurname { get; set; }
    public string? AuthorizedSecondSurname { get; set; }
    public string? AuthorizedSecondName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string PostalCode { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public byte EmployeeCount { get; set; }

    public string[] Roles => new[] { Admin, Write, EstateAgentsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetEstateAgents";

    public class UpdateEstateAgentCommandHandler : IRequestHandler<UpdateEstateAgentCommand, UpdatedEstateAgentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEstateAgentRepository _estateAgentRepository;
        private readonly EstateAgentBusinessRules _estateAgentBusinessRules;

        public UpdateEstateAgentCommandHandler(IMapper mapper, IEstateAgentRepository estateAgentRepository,
                                         EstateAgentBusinessRules estateAgentBusinessRules)
        {
            _mapper = mapper;
            _estateAgentRepository = estateAgentRepository;
            _estateAgentBusinessRules = estateAgentBusinessRules;
        }

        public async Task<UpdatedEstateAgentResponse> Handle(UpdateEstateAgentCommand request, CancellationToken cancellationToken)
        {
            EstateAgent? estateAgent = await _estateAgentRepository.GetAsync(predicate: ea => ea.Id == request.Id, cancellationToken: cancellationToken);
            await _estateAgentBusinessRules.EstateAgentShouldExistWhenSelected(estateAgent);
            estateAgent = _mapper.Map(request, estateAgent);

            await _estateAgentRepository.UpdateAsync(estateAgent!);

            UpdatedEstateAgentResponse response = _mapper.Map<UpdatedEstateAgentResponse>(estateAgent);
            return response;
        }
    }
}
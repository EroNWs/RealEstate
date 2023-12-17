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

namespace Application.Features.EstateAgents.Commands.Create;

public class CreateEstateAgentCommand : IRequest<CreatedEstateAgentResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
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

    public string[] Roles => new[] { Admin, Write, EstateAgentsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetEstateAgents";

    public class CreateEstateAgentCommandHandler : IRequestHandler<CreateEstateAgentCommand, CreatedEstateAgentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEstateAgentRepository _estateAgentRepository;
        private readonly EstateAgentBusinessRules _estateAgentBusinessRules;

        public CreateEstateAgentCommandHandler(IMapper mapper, IEstateAgentRepository estateAgentRepository,
                                         EstateAgentBusinessRules estateAgentBusinessRules)
        {
            _mapper = mapper;
            _estateAgentRepository = estateAgentRepository;
            _estateAgentBusinessRules = estateAgentBusinessRules;
        }

        public async Task<CreatedEstateAgentResponse> Handle(CreateEstateAgentCommand request, CancellationToken cancellationToken)
        {
            EstateAgent estateAgent = _mapper.Map<EstateAgent>(request);

            await _estateAgentRepository.AddAsync(estateAgent);

            CreatedEstateAgentResponse response = _mapper.Map<CreatedEstateAgentResponse>(estateAgent);
            return response;
        }
    }
}
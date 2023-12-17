using Application.Features.EstateAgents.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.EstateAgents.Constants.EstateAgentsOperationClaims;

namespace Application.Features.EstateAgents.Queries.GetList;

public class GetListEstateAgentQuery : IRequest<GetListResponse<GetListEstateAgentListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListEstateAgents({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetEstateAgents";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListEstateAgentQueryHandler : IRequestHandler<GetListEstateAgentQuery, GetListResponse<GetListEstateAgentListItemDto>>
    {
        private readonly IEstateAgentRepository _estateAgentRepository;
        private readonly IMapper _mapper;

        public GetListEstateAgentQueryHandler(IEstateAgentRepository estateAgentRepository, IMapper mapper)
        {
            _estateAgentRepository = estateAgentRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListEstateAgentListItemDto>> Handle(GetListEstateAgentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<EstateAgent> estateAgents = await _estateAgentRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListEstateAgentListItemDto> response = _mapper.Map<GetListResponse<GetListEstateAgentListItemDto>>(estateAgents);
            return response;
        }
    }
}
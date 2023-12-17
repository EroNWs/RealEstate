using Application.Features.RealEstates.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.RealEstates.Constants.RealEstatesOperationClaims;

namespace Application.Features.RealEstates.Queries.GetList;

public class GetListRealEstateQuery : IRequest<GetListResponse<GetListRealEstateListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListRealEstates({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetRealEstates";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListRealEstateQueryHandler : IRequestHandler<GetListRealEstateQuery, GetListResponse<GetListRealEstateListItemDto>>
    {
        private readonly IRealEstateRepository _realEstateRepository;
        private readonly IMapper _mapper;

        public GetListRealEstateQueryHandler(IRealEstateRepository realEstateRepository, IMapper mapper)
        {
            _realEstateRepository = realEstateRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRealEstateListItemDto>> Handle(GetListRealEstateQuery request, CancellationToken cancellationToken)
        {
            IPaginate<RealEstate> realEstates = await _realEstateRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRealEstateListItemDto> response = _mapper.Map<GetListResponse<GetListRealEstateListItemDto>>(realEstates);
            return response;
        }
    }
}
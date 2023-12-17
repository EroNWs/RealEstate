using Application.Features.RealEstateTransactionForRentals.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.RealEstateTransactionForRentals.Constants.RealEstateTransactionForRentalsOperationClaims;

namespace Application.Features.RealEstateTransactionForRentals.Queries.GetList;

public class GetListRealEstateTransactionForRentalQuery : IRequest<GetListResponse<GetListRealEstateTransactionForRentalListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListRealEstateTransactionForRentals({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetRealEstateTransactionForRentals";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListRealEstateTransactionForRentalQueryHandler : IRequestHandler<GetListRealEstateTransactionForRentalQuery, GetListResponse<GetListRealEstateTransactionForRentalListItemDto>>
    {
        private readonly IRealEstateTransactionForRentalRepository _realEstateTransactionForRentalRepository;
        private readonly IMapper _mapper;

        public GetListRealEstateTransactionForRentalQueryHandler(IRealEstateTransactionForRentalRepository realEstateTransactionForRentalRepository, IMapper mapper)
        {
            _realEstateTransactionForRentalRepository = realEstateTransactionForRentalRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRealEstateTransactionForRentalListItemDto>> Handle(GetListRealEstateTransactionForRentalQuery request, CancellationToken cancellationToken)
        {
            IPaginate<RealEstateTransactionForRental> realEstateTransactionForRentals = await _realEstateTransactionForRentalRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRealEstateTransactionForRentalListItemDto> response = _mapper.Map<GetListResponse<GetListRealEstateTransactionForRentalListItemDto>>(realEstateTransactionForRentals);
            return response;
        }
    }
}
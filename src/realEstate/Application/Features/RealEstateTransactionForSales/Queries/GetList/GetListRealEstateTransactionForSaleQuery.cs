using Application.Features.RealEstateTransactionForSales.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.RealEstateTransactionForSales.Constants.RealEstateTransactionForSalesOperationClaims;

namespace Application.Features.RealEstateTransactionForSales.Queries.GetList;

public class GetListRealEstateTransactionForSaleQuery : IRequest<GetListResponse<GetListRealEstateTransactionForSaleListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListRealEstateTransactionForSales({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetRealEstateTransactionForSales";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListRealEstateTransactionForSaleQueryHandler : IRequestHandler<GetListRealEstateTransactionForSaleQuery, GetListResponse<GetListRealEstateTransactionForSaleListItemDto>>
    {
        private readonly IRealEstateTransactionForSaleRepository _realEstateTransactionForSaleRepository;
        private readonly IMapper _mapper;

        public GetListRealEstateTransactionForSaleQueryHandler(IRealEstateTransactionForSaleRepository realEstateTransactionForSaleRepository, IMapper mapper)
        {
            _realEstateTransactionForSaleRepository = realEstateTransactionForSaleRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRealEstateTransactionForSaleListItemDto>> Handle(GetListRealEstateTransactionForSaleQuery request, CancellationToken cancellationToken)
        {
            IPaginate<RealEstateTransactionForSale> realEstateTransactionForSales = await _realEstateTransactionForSaleRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRealEstateTransactionForSaleListItemDto> response = _mapper.Map<GetListResponse<GetListRealEstateTransactionForSaleListItemDto>>(realEstateTransactionForSales);
            return response;
        }
    }
}
using Application.Features.RealEstateTransactionForSales.Constants;
using Application.Features.RealEstateTransactionForSales.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.RealEstateTransactionForSales.Constants.RealEstateTransactionForSalesOperationClaims;

namespace Application.Features.RealEstateTransactionForSales.Queries.GetById;

public class GetByIdRealEstateTransactionForSaleQuery : IRequest<GetByIdRealEstateTransactionForSaleResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdRealEstateTransactionForSaleQueryHandler : IRequestHandler<GetByIdRealEstateTransactionForSaleQuery, GetByIdRealEstateTransactionForSaleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRealEstateTransactionForSaleRepository _realEstateTransactionForSaleRepository;
        private readonly RealEstateTransactionForSaleBusinessRules _realEstateTransactionForSaleBusinessRules;

        public GetByIdRealEstateTransactionForSaleQueryHandler(IMapper mapper, IRealEstateTransactionForSaleRepository realEstateTransactionForSaleRepository, RealEstateTransactionForSaleBusinessRules realEstateTransactionForSaleBusinessRules)
        {
            _mapper = mapper;
            _realEstateTransactionForSaleRepository = realEstateTransactionForSaleRepository;
            _realEstateTransactionForSaleBusinessRules = realEstateTransactionForSaleBusinessRules;
        }

        public async Task<GetByIdRealEstateTransactionForSaleResponse> Handle(GetByIdRealEstateTransactionForSaleQuery request, CancellationToken cancellationToken)
        {
            RealEstateTransactionForSale? realEstateTransactionForSale = await _realEstateTransactionForSaleRepository.GetAsync(predicate: retfs => retfs.Id == request.Id, cancellationToken: cancellationToken);
            await _realEstateTransactionForSaleBusinessRules.RealEstateTransactionForSaleShouldExistWhenSelected(realEstateTransactionForSale);

            GetByIdRealEstateTransactionForSaleResponse response = _mapper.Map<GetByIdRealEstateTransactionForSaleResponse>(realEstateTransactionForSale);
            return response;
        }
    }
}
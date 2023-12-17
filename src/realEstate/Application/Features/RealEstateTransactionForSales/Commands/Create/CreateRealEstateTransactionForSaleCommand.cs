using Application.Features.RealEstateTransactionForSales.Constants;
using Application.Features.RealEstateTransactionForSales.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.RealEstateTransactionForSales.Constants.RealEstateTransactionForSalesOperationClaims;

namespace Application.Features.RealEstateTransactionForSales.Commands.Create;

public class CreateRealEstateTransactionForSaleCommand : IRequest<CreatedRealEstateTransactionForSaleResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid RealEstateId { get; set; }
    public RealEstate RealEstate { get; set; }
    public Guid EstateAgentId { get; set; }
    public EstateAgent EstateAgent { get; set; }
    public Guid BuyerId { get; set; }
    public Customer Buyer { get; set; }
    public Guid SellerId { get; set; }
    public Customer Seller { get; set; }

    public string[] Roles => new[] { Admin, Write, RealEstateTransactionForSalesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRealEstateTransactionForSales";

    public class CreateRealEstateTransactionForSaleCommandHandler : IRequestHandler<CreateRealEstateTransactionForSaleCommand, CreatedRealEstateTransactionForSaleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRealEstateTransactionForSaleRepository _realEstateTransactionForSaleRepository;
        private readonly RealEstateTransactionForSaleBusinessRules _realEstateTransactionForSaleBusinessRules;

        public CreateRealEstateTransactionForSaleCommandHandler(IMapper mapper, IRealEstateTransactionForSaleRepository realEstateTransactionForSaleRepository,
                                         RealEstateTransactionForSaleBusinessRules realEstateTransactionForSaleBusinessRules)
        {
            _mapper = mapper;
            _realEstateTransactionForSaleRepository = realEstateTransactionForSaleRepository;
            _realEstateTransactionForSaleBusinessRules = realEstateTransactionForSaleBusinessRules;
        }

        public async Task<CreatedRealEstateTransactionForSaleResponse> Handle(CreateRealEstateTransactionForSaleCommand request, CancellationToken cancellationToken)
        {
            RealEstateTransactionForSale realEstateTransactionForSale = _mapper.Map<RealEstateTransactionForSale>(request);

            await _realEstateTransactionForSaleRepository.AddAsync(realEstateTransactionForSale);

            CreatedRealEstateTransactionForSaleResponse response = _mapper.Map<CreatedRealEstateTransactionForSaleResponse>(realEstateTransactionForSale);
            return response;
        }
    }
}
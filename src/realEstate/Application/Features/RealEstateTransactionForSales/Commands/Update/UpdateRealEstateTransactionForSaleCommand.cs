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

namespace Application.Features.RealEstateTransactionForSales.Commands.Update;

public class UpdateRealEstateTransactionForSaleCommand : IRequest<UpdatedRealEstateTransactionForSaleResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid RealEstateId { get; set; }
    public RealEstate RealEstate { get; set; }
    public Guid EstateAgentId { get; set; }
    public EstateAgent EstateAgent { get; set; }
    public Guid BuyerId { get; set; }
    public Customer Buyer { get; set; }
    public Guid SellerId { get; set; }
    public Customer Seller { get; set; }

    public string[] Roles => new[] { Admin, Write, RealEstateTransactionForSalesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRealEstateTransactionForSales";

    public class UpdateRealEstateTransactionForSaleCommandHandler : IRequestHandler<UpdateRealEstateTransactionForSaleCommand, UpdatedRealEstateTransactionForSaleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRealEstateTransactionForSaleRepository _realEstateTransactionForSaleRepository;
        private readonly RealEstateTransactionForSaleBusinessRules _realEstateTransactionForSaleBusinessRules;

        public UpdateRealEstateTransactionForSaleCommandHandler(IMapper mapper, IRealEstateTransactionForSaleRepository realEstateTransactionForSaleRepository,
                                         RealEstateTransactionForSaleBusinessRules realEstateTransactionForSaleBusinessRules)
        {
            _mapper = mapper;
            _realEstateTransactionForSaleRepository = realEstateTransactionForSaleRepository;
            _realEstateTransactionForSaleBusinessRules = realEstateTransactionForSaleBusinessRules;
        }

        public async Task<UpdatedRealEstateTransactionForSaleResponse> Handle(UpdateRealEstateTransactionForSaleCommand request, CancellationToken cancellationToken)
        {
            RealEstateTransactionForSale? realEstateTransactionForSale = await _realEstateTransactionForSaleRepository.GetAsync(predicate: retfs => retfs.Id == request.Id, cancellationToken: cancellationToken);
            await _realEstateTransactionForSaleBusinessRules.RealEstateTransactionForSaleShouldExistWhenSelected(realEstateTransactionForSale);
            realEstateTransactionForSale = _mapper.Map(request, realEstateTransactionForSale);

            await _realEstateTransactionForSaleRepository.UpdateAsync(realEstateTransactionForSale!);

            UpdatedRealEstateTransactionForSaleResponse response = _mapper.Map<UpdatedRealEstateTransactionForSaleResponse>(realEstateTransactionForSale);
            return response;
        }
    }
}
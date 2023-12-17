using Application.Features.RealEstateTransactionForSales.Constants;
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

namespace Application.Features.RealEstateTransactionForSales.Commands.Delete;

public class DeleteRealEstateTransactionForSaleCommand : IRequest<DeletedRealEstateTransactionForSaleResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, RealEstateTransactionForSalesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRealEstateTransactionForSales";

    public class DeleteRealEstateTransactionForSaleCommandHandler : IRequestHandler<DeleteRealEstateTransactionForSaleCommand, DeletedRealEstateTransactionForSaleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRealEstateTransactionForSaleRepository _realEstateTransactionForSaleRepository;
        private readonly RealEstateTransactionForSaleBusinessRules _realEstateTransactionForSaleBusinessRules;

        public DeleteRealEstateTransactionForSaleCommandHandler(IMapper mapper, IRealEstateTransactionForSaleRepository realEstateTransactionForSaleRepository,
                                         RealEstateTransactionForSaleBusinessRules realEstateTransactionForSaleBusinessRules)
        {
            _mapper = mapper;
            _realEstateTransactionForSaleRepository = realEstateTransactionForSaleRepository;
            _realEstateTransactionForSaleBusinessRules = realEstateTransactionForSaleBusinessRules;
        }

        public async Task<DeletedRealEstateTransactionForSaleResponse> Handle(DeleteRealEstateTransactionForSaleCommand request, CancellationToken cancellationToken)
        {
            RealEstateTransactionForSale? realEstateTransactionForSale = await _realEstateTransactionForSaleRepository.GetAsync(predicate: retfs => retfs.Id == request.Id, cancellationToken: cancellationToken);
            await _realEstateTransactionForSaleBusinessRules.RealEstateTransactionForSaleShouldExistWhenSelected(realEstateTransactionForSale);

            await _realEstateTransactionForSaleRepository.DeleteAsync(realEstateTransactionForSale!);

            DeletedRealEstateTransactionForSaleResponse response = _mapper.Map<DeletedRealEstateTransactionForSaleResponse>(realEstateTransactionForSale);
            return response;
        }
    }
}
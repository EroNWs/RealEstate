using Application.Features.RealEstateTransactionForRentals.Constants;
using Application.Features.RealEstateTransactionForRentals.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.RealEstateTransactionForRentals.Constants.RealEstateTransactionForRentalsOperationClaims;

namespace Application.Features.RealEstateTransactionForRentals.Commands.Update;

public class UpdateRealEstateTransactionForRentalCommand : IRequest<UpdatedRealEstateTransactionForRentalResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid RealEstateId { get; set; }
    public RealEstate RealEstate { get; set; }
    public Guid EtateAgentId { get; set; }
    public EstateAgent EstateAgent { get; set; }
    public Guid TenantId { get; set; }
    public Customer Tenant { get; set; }
    public Guid RenterId { get; set; }
    public Customer Renter { get; set; }

    public string[] Roles => new[] { Admin, Write, RealEstateTransactionForRentalsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRealEstateTransactionForRentals";

    public class UpdateRealEstateTransactionForRentalCommandHandler : IRequestHandler<UpdateRealEstateTransactionForRentalCommand, UpdatedRealEstateTransactionForRentalResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRealEstateTransactionForRentalRepository _realEstateTransactionForRentalRepository;
        private readonly RealEstateTransactionForRentalBusinessRules _realEstateTransactionForRentalBusinessRules;

        public UpdateRealEstateTransactionForRentalCommandHandler(IMapper mapper, IRealEstateTransactionForRentalRepository realEstateTransactionForRentalRepository,
                                         RealEstateTransactionForRentalBusinessRules realEstateTransactionForRentalBusinessRules)
        {
            _mapper = mapper;
            _realEstateTransactionForRentalRepository = realEstateTransactionForRentalRepository;
            _realEstateTransactionForRentalBusinessRules = realEstateTransactionForRentalBusinessRules;
        }

        public async Task<UpdatedRealEstateTransactionForRentalResponse> Handle(UpdateRealEstateTransactionForRentalCommand request, CancellationToken cancellationToken)
        {
            RealEstateTransactionForRental? realEstateTransactionForRental = await _realEstateTransactionForRentalRepository.GetAsync(predicate: retfr => retfr.Id == request.Id, cancellationToken: cancellationToken);
            await _realEstateTransactionForRentalBusinessRules.RealEstateTransactionForRentalShouldExistWhenSelected(realEstateTransactionForRental);
            realEstateTransactionForRental = _mapper.Map(request, realEstateTransactionForRental);

            await _realEstateTransactionForRentalRepository.UpdateAsync(realEstateTransactionForRental!);

            UpdatedRealEstateTransactionForRentalResponse response = _mapper.Map<UpdatedRealEstateTransactionForRentalResponse>(realEstateTransactionForRental);
            return response;
        }
    }
}
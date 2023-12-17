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

namespace Application.Features.RealEstateTransactionForRentals.Commands.Create;

public class CreateRealEstateTransactionForRentalCommand : IRequest<CreatedRealEstateTransactionForRentalResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid RealEstateId { get; set; }
    public RealEstate RealEstate { get; set; }
    public Guid EtateAgentId { get; set; }
    public EstateAgent EstateAgent { get; set; }
    public Guid TenantId { get; set; }
    public Customer Tenant { get; set; }
    public Guid RenterId { get; set; }
    public Customer Renter { get; set; }

    public string[] Roles => new[] { Admin, Write, RealEstateTransactionForRentalsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRealEstateTransactionForRentals";

    public class CreateRealEstateTransactionForRentalCommandHandler : IRequestHandler<CreateRealEstateTransactionForRentalCommand, CreatedRealEstateTransactionForRentalResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRealEstateTransactionForRentalRepository _realEstateTransactionForRentalRepository;
        private readonly RealEstateTransactionForRentalBusinessRules _realEstateTransactionForRentalBusinessRules;

        public CreateRealEstateTransactionForRentalCommandHandler(IMapper mapper, IRealEstateTransactionForRentalRepository realEstateTransactionForRentalRepository,
                                         RealEstateTransactionForRentalBusinessRules realEstateTransactionForRentalBusinessRules)
        {
            _mapper = mapper;
            _realEstateTransactionForRentalRepository = realEstateTransactionForRentalRepository;
            _realEstateTransactionForRentalBusinessRules = realEstateTransactionForRentalBusinessRules;
        }

        public async Task<CreatedRealEstateTransactionForRentalResponse> Handle(CreateRealEstateTransactionForRentalCommand request, CancellationToken cancellationToken)
        {
            RealEstateTransactionForRental realEstateTransactionForRental = _mapper.Map<RealEstateTransactionForRental>(request);

            await _realEstateTransactionForRentalRepository.AddAsync(realEstateTransactionForRental);

            CreatedRealEstateTransactionForRentalResponse response = _mapper.Map<CreatedRealEstateTransactionForRentalResponse>(realEstateTransactionForRental);
            return response;
        }
    }
}
using Application.Features.RealEstates.Constants;
using Application.Features.RealEstates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using Domain.Enums;
using Domain.Enums;
using Domain.Enums;
using static Application.Features.RealEstates.Constants.RealEstatesOperationClaims;

namespace Application.Features.RealEstates.Commands.Create;

public class CreateRealEstateCommand : IRequest<CreatedRealEstateResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public RealEstateType Type { get; set; }
    public Status Status { get; set; }
    public decimal SquareMeters { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public Guid? TransactionId { get; set; }
    public TransactionType TransactionType { get; set; }

    public string[] Roles => new[] { Admin, Write, RealEstatesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRealEstates";

    public class CreateRealEstateCommandHandler : IRequestHandler<CreateRealEstateCommand, CreatedRealEstateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRealEstateRepository _realEstateRepository;
        private readonly RealEstateBusinessRules _realEstateBusinessRules;

        public CreateRealEstateCommandHandler(IMapper mapper, IRealEstateRepository realEstateRepository,
                                         RealEstateBusinessRules realEstateBusinessRules)
        {
            _mapper = mapper;
            _realEstateRepository = realEstateRepository;
            _realEstateBusinessRules = realEstateBusinessRules;
        }

        public async Task<CreatedRealEstateResponse> Handle(CreateRealEstateCommand request, CancellationToken cancellationToken)
        {
            RealEstate realEstate = _mapper.Map<RealEstate>(request);

            await _realEstateRepository.AddAsync(realEstate);

            CreatedRealEstateResponse response = _mapper.Map<CreatedRealEstateResponse>(realEstate);
            return response;
        }
    }
}
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

namespace Application.Features.RealEstates.Commands.Update;

public class UpdateRealEstateCommand : IRequest<UpdatedRealEstateResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public RealEstateType Type { get; set; }
    public Status Status { get; set; }
    public decimal SquareMeters { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public Guid? TransactionId { get; set; }
    public TransactionType TransactionType { get; set; }

    public string[] Roles => new[] { Admin, Write, RealEstatesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRealEstates";

    public class UpdateRealEstateCommandHandler : IRequestHandler<UpdateRealEstateCommand, UpdatedRealEstateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRealEstateRepository _realEstateRepository;
        private readonly RealEstateBusinessRules _realEstateBusinessRules;

        public UpdateRealEstateCommandHandler(IMapper mapper, IRealEstateRepository realEstateRepository,
                                         RealEstateBusinessRules realEstateBusinessRules)
        {
            _mapper = mapper;
            _realEstateRepository = realEstateRepository;
            _realEstateBusinessRules = realEstateBusinessRules;
        }

        public async Task<UpdatedRealEstateResponse> Handle(UpdateRealEstateCommand request, CancellationToken cancellationToken)
        {
            RealEstate? realEstate = await _realEstateRepository.GetAsync(predicate: re => re.Id == request.Id, cancellationToken: cancellationToken);
            await _realEstateBusinessRules.RealEstateShouldExistWhenSelected(realEstate);
            realEstate = _mapper.Map(request, realEstate);

            await _realEstateRepository.UpdateAsync(realEstate!);

            UpdatedRealEstateResponse response = _mapper.Map<UpdatedRealEstateResponse>(realEstate);
            return response;
        }
    }
}
using Application.Features.RealEstates.Constants;
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
using static Application.Features.RealEstates.Constants.RealEstatesOperationClaims;

namespace Application.Features.RealEstates.Commands.Delete;

public class DeleteRealEstateCommand : IRequest<DeletedRealEstateResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, RealEstatesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRealEstates";

    public class DeleteRealEstateCommandHandler : IRequestHandler<DeleteRealEstateCommand, DeletedRealEstateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRealEstateRepository _realEstateRepository;
        private readonly RealEstateBusinessRules _realEstateBusinessRules;

        public DeleteRealEstateCommandHandler(IMapper mapper, IRealEstateRepository realEstateRepository,
                                         RealEstateBusinessRules realEstateBusinessRules)
        {
            _mapper = mapper;
            _realEstateRepository = realEstateRepository;
            _realEstateBusinessRules = realEstateBusinessRules;
        }

        public async Task<DeletedRealEstateResponse> Handle(DeleteRealEstateCommand request, CancellationToken cancellationToken)
        {
            RealEstate? realEstate = await _realEstateRepository.GetAsync(predicate: re => re.Id == request.Id, cancellationToken: cancellationToken);
            await _realEstateBusinessRules.RealEstateShouldExistWhenSelected(realEstate);

            await _realEstateRepository.DeleteAsync(realEstate!);

            DeletedRealEstateResponse response = _mapper.Map<DeletedRealEstateResponse>(realEstate);
            return response;
        }
    }
}
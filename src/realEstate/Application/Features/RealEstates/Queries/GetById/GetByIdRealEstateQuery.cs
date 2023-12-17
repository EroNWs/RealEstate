using Application.Features.RealEstates.Constants;
using Application.Features.RealEstates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.RealEstates.Constants.RealEstatesOperationClaims;

namespace Application.Features.RealEstates.Queries.GetById;

public class GetByIdRealEstateQuery : IRequest<GetByIdRealEstateResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdRealEstateQueryHandler : IRequestHandler<GetByIdRealEstateQuery, GetByIdRealEstateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRealEstateRepository _realEstateRepository;
        private readonly RealEstateBusinessRules _realEstateBusinessRules;

        public GetByIdRealEstateQueryHandler(IMapper mapper, IRealEstateRepository realEstateRepository, RealEstateBusinessRules realEstateBusinessRules)
        {
            _mapper = mapper;
            _realEstateRepository = realEstateRepository;
            _realEstateBusinessRules = realEstateBusinessRules;
        }

        public async Task<GetByIdRealEstateResponse> Handle(GetByIdRealEstateQuery request, CancellationToken cancellationToken)
        {
            RealEstate? realEstate = await _realEstateRepository.GetAsync(predicate: re => re.Id == request.Id, cancellationToken: cancellationToken);
            await _realEstateBusinessRules.RealEstateShouldExistWhenSelected(realEstate);

            GetByIdRealEstateResponse response = _mapper.Map<GetByIdRealEstateResponse>(realEstate);
            return response;
        }
    }
}
using Application.Features.RealEstateTransactionForRentals.Constants;
using Application.Features.RealEstateTransactionForRentals.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.RealEstateTransactionForRentals.Constants.RealEstateTransactionForRentalsOperationClaims;

namespace Application.Features.RealEstateTransactionForRentals.Queries.GetById;

public class GetByIdRealEstateTransactionForRentalQuery : IRequest<GetByIdRealEstateTransactionForRentalResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdRealEstateTransactionForRentalQueryHandler : IRequestHandler<GetByIdRealEstateTransactionForRentalQuery, GetByIdRealEstateTransactionForRentalResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRealEstateTransactionForRentalRepository _realEstateTransactionForRentalRepository;
        private readonly RealEstateTransactionForRentalBusinessRules _realEstateTransactionForRentalBusinessRules;

        public GetByIdRealEstateTransactionForRentalQueryHandler(IMapper mapper, IRealEstateTransactionForRentalRepository realEstateTransactionForRentalRepository, RealEstateTransactionForRentalBusinessRules realEstateTransactionForRentalBusinessRules)
        {
            _mapper = mapper;
            _realEstateTransactionForRentalRepository = realEstateTransactionForRentalRepository;
            _realEstateTransactionForRentalBusinessRules = realEstateTransactionForRentalBusinessRules;
        }

        public async Task<GetByIdRealEstateTransactionForRentalResponse> Handle(GetByIdRealEstateTransactionForRentalQuery request, CancellationToken cancellationToken)
        {
            RealEstateTransactionForRental? realEstateTransactionForRental = await _realEstateTransactionForRentalRepository.GetAsync(predicate: retfr => retfr.Id == request.Id, cancellationToken: cancellationToken);
            await _realEstateTransactionForRentalBusinessRules.RealEstateTransactionForRentalShouldExistWhenSelected(realEstateTransactionForRental);

            GetByIdRealEstateTransactionForRentalResponse response = _mapper.Map<GetByIdRealEstateTransactionForRentalResponse>(realEstateTransactionForRental);
            return response;
        }
    }
}
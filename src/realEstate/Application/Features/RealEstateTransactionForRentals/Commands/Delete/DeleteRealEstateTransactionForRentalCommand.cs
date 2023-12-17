using Application.Features.RealEstateTransactionForRentals.Constants;
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

namespace Application.Features.RealEstateTransactionForRentals.Commands.Delete;

public class DeleteRealEstateTransactionForRentalCommand : IRequest<DeletedRealEstateTransactionForRentalResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, RealEstateTransactionForRentalsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRealEstateTransactionForRentals";

    public class DeleteRealEstateTransactionForRentalCommandHandler : IRequestHandler<DeleteRealEstateTransactionForRentalCommand, DeletedRealEstateTransactionForRentalResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRealEstateTransactionForRentalRepository _realEstateTransactionForRentalRepository;
        private readonly RealEstateTransactionForRentalBusinessRules _realEstateTransactionForRentalBusinessRules;

        public DeleteRealEstateTransactionForRentalCommandHandler(IMapper mapper, IRealEstateTransactionForRentalRepository realEstateTransactionForRentalRepository,
                                         RealEstateTransactionForRentalBusinessRules realEstateTransactionForRentalBusinessRules)
        {
            _mapper = mapper;
            _realEstateTransactionForRentalRepository = realEstateTransactionForRentalRepository;
            _realEstateTransactionForRentalBusinessRules = realEstateTransactionForRentalBusinessRules;
        }

        public async Task<DeletedRealEstateTransactionForRentalResponse> Handle(DeleteRealEstateTransactionForRentalCommand request, CancellationToken cancellationToken)
        {
            RealEstateTransactionForRental? realEstateTransactionForRental = await _realEstateTransactionForRentalRepository.GetAsync(predicate: retfr => retfr.Id == request.Id, cancellationToken: cancellationToken);
            await _realEstateTransactionForRentalBusinessRules.RealEstateTransactionForRentalShouldExistWhenSelected(realEstateTransactionForRental);

            await _realEstateTransactionForRentalRepository.DeleteAsync(realEstateTransactionForRental!);

            DeletedRealEstateTransactionForRentalResponse response = _mapper.Map<DeletedRealEstateTransactionForRentalResponse>(realEstateTransactionForRental);
            return response;
        }
    }
}
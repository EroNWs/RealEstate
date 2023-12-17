using Application.Features.RealEstateTransactionForRentals.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.RealEstateTransactionForRentals.Rules;

public class RealEstateTransactionForRentalBusinessRules : BaseBusinessRules
{
    private readonly IRealEstateTransactionForRentalRepository _realEstateTransactionForRentalRepository;

    public RealEstateTransactionForRentalBusinessRules(IRealEstateTransactionForRentalRepository realEstateTransactionForRentalRepository)
    {
        _realEstateTransactionForRentalRepository = realEstateTransactionForRentalRepository;
    }

    public Task RealEstateTransactionForRentalShouldExistWhenSelected(RealEstateTransactionForRental? realEstateTransactionForRental)
    {
        if (realEstateTransactionForRental == null)
            throw new BusinessException(RealEstateTransactionForRentalsBusinessMessages.RealEstateTransactionForRentalNotExists);
        return Task.CompletedTask;
    }

    public async Task RealEstateTransactionForRentalIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        RealEstateTransactionForRental? realEstateTransactionForRental = await _realEstateTransactionForRentalRepository.GetAsync(
            predicate: retfr => retfr.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RealEstateTransactionForRentalShouldExistWhenSelected(realEstateTransactionForRental);
    }
}
using Application.Features.RealEstateTransactionForRentals.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RealEstateTransactionForRentals;

public class RealEstateTransactionForRentalsManager : IRealEstateTransactionForRentalsService
{
    private readonly IRealEstateTransactionForRentalRepository _realEstateTransactionForRentalRepository;
    private readonly RealEstateTransactionForRentalBusinessRules _realEstateTransactionForRentalBusinessRules;

    public RealEstateTransactionForRentalsManager(IRealEstateTransactionForRentalRepository realEstateTransactionForRentalRepository, RealEstateTransactionForRentalBusinessRules realEstateTransactionForRentalBusinessRules)
    {
        _realEstateTransactionForRentalRepository = realEstateTransactionForRentalRepository;
        _realEstateTransactionForRentalBusinessRules = realEstateTransactionForRentalBusinessRules;
    }

    public async Task<RealEstateTransactionForRental?> GetAsync(
        Expression<Func<RealEstateTransactionForRental, bool>> predicate,
        Func<IQueryable<RealEstateTransactionForRental>, IIncludableQueryable<RealEstateTransactionForRental, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        RealEstateTransactionForRental? realEstateTransactionForRental = await _realEstateTransactionForRentalRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return realEstateTransactionForRental;
    }

    public async Task<IPaginate<RealEstateTransactionForRental>?> GetListAsync(
        Expression<Func<RealEstateTransactionForRental, bool>>? predicate = null,
        Func<IQueryable<RealEstateTransactionForRental>, IOrderedQueryable<RealEstateTransactionForRental>>? orderBy = null,
        Func<IQueryable<RealEstateTransactionForRental>, IIncludableQueryable<RealEstateTransactionForRental, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<RealEstateTransactionForRental> realEstateTransactionForRentalList = await _realEstateTransactionForRentalRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return realEstateTransactionForRentalList;
    }

    public async Task<RealEstateTransactionForRental> AddAsync(RealEstateTransactionForRental realEstateTransactionForRental)
    {
        RealEstateTransactionForRental addedRealEstateTransactionForRental = await _realEstateTransactionForRentalRepository.AddAsync(realEstateTransactionForRental);

        return addedRealEstateTransactionForRental;
    }

    public async Task<RealEstateTransactionForRental> UpdateAsync(RealEstateTransactionForRental realEstateTransactionForRental)
    {
        RealEstateTransactionForRental updatedRealEstateTransactionForRental = await _realEstateTransactionForRentalRepository.UpdateAsync(realEstateTransactionForRental);

        return updatedRealEstateTransactionForRental;
    }

    public async Task<RealEstateTransactionForRental> DeleteAsync(RealEstateTransactionForRental realEstateTransactionForRental, bool permanent = false)
    {
        RealEstateTransactionForRental deletedRealEstateTransactionForRental = await _realEstateTransactionForRentalRepository.DeleteAsync(realEstateTransactionForRental);

        return deletedRealEstateTransactionForRental;
    }
}

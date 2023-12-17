using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RealEstateTransactionForRentals;

public interface IRealEstateTransactionForRentalsService
{
    Task<RealEstateTransactionForRental?> GetAsync(
        Expression<Func<RealEstateTransactionForRental, bool>> predicate,
        Func<IQueryable<RealEstateTransactionForRental>, IIncludableQueryable<RealEstateTransactionForRental, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<RealEstateTransactionForRental>?> GetListAsync(
        Expression<Func<RealEstateTransactionForRental, bool>>? predicate = null,
        Func<IQueryable<RealEstateTransactionForRental>, IOrderedQueryable<RealEstateTransactionForRental>>? orderBy = null,
        Func<IQueryable<RealEstateTransactionForRental>, IIncludableQueryable<RealEstateTransactionForRental, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<RealEstateTransactionForRental> AddAsync(RealEstateTransactionForRental realEstateTransactionForRental);
    Task<RealEstateTransactionForRental> UpdateAsync(RealEstateTransactionForRental realEstateTransactionForRental);
    Task<RealEstateTransactionForRental> DeleteAsync(RealEstateTransactionForRental realEstateTransactionForRental, bool permanent = false);
}

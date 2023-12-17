using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RealEstateTransactionForSales;

public interface IRealEstateTransactionForSalesService
{
    Task<RealEstateTransactionForSale?> GetAsync(
        Expression<Func<RealEstateTransactionForSale, bool>> predicate,
        Func<IQueryable<RealEstateTransactionForSale>, IIncludableQueryable<RealEstateTransactionForSale, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<RealEstateTransactionForSale>?> GetListAsync(
        Expression<Func<RealEstateTransactionForSale, bool>>? predicate = null,
        Func<IQueryable<RealEstateTransactionForSale>, IOrderedQueryable<RealEstateTransactionForSale>>? orderBy = null,
        Func<IQueryable<RealEstateTransactionForSale>, IIncludableQueryable<RealEstateTransactionForSale, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<RealEstateTransactionForSale> AddAsync(RealEstateTransactionForSale realEstateTransactionForSale);
    Task<RealEstateTransactionForSale> UpdateAsync(RealEstateTransactionForSale realEstateTransactionForSale);
    Task<RealEstateTransactionForSale> DeleteAsync(RealEstateTransactionForSale realEstateTransactionForSale, bool permanent = false);
}

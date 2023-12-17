using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RealEstates;

public interface IRealEstatesService
{
    Task<RealEstate?> GetAsync(
        Expression<Func<RealEstate, bool>> predicate,
        Func<IQueryable<RealEstate>, IIncludableQueryable<RealEstate, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<RealEstate>?> GetListAsync(
        Expression<Func<RealEstate, bool>>? predicate = null,
        Func<IQueryable<RealEstate>, IOrderedQueryable<RealEstate>>? orderBy = null,
        Func<IQueryable<RealEstate>, IIncludableQueryable<RealEstate, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<RealEstate> AddAsync(RealEstate realEstate);
    Task<RealEstate> UpdateAsync(RealEstate realEstate);
    Task<RealEstate> DeleteAsync(RealEstate realEstate, bool permanent = false);
}

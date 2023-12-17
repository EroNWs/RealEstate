using Application.Features.RealEstates.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RealEstates;

public class RealEstatesManager : IRealEstatesService
{
    private readonly IRealEstateRepository _realEstateRepository;
    private readonly RealEstateBusinessRules _realEstateBusinessRules;

    public RealEstatesManager(IRealEstateRepository realEstateRepository, RealEstateBusinessRules realEstateBusinessRules)
    {
        _realEstateRepository = realEstateRepository;
        _realEstateBusinessRules = realEstateBusinessRules;
    }

    public async Task<RealEstate?> GetAsync(
        Expression<Func<RealEstate, bool>> predicate,
        Func<IQueryable<RealEstate>, IIncludableQueryable<RealEstate, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        RealEstate? realEstate = await _realEstateRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return realEstate;
    }

    public async Task<IPaginate<RealEstate>?> GetListAsync(
        Expression<Func<RealEstate, bool>>? predicate = null,
        Func<IQueryable<RealEstate>, IOrderedQueryable<RealEstate>>? orderBy = null,
        Func<IQueryable<RealEstate>, IIncludableQueryable<RealEstate, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<RealEstate> realEstateList = await _realEstateRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return realEstateList;
    }

    public async Task<RealEstate> AddAsync(RealEstate realEstate)
    {
        RealEstate addedRealEstate = await _realEstateRepository.AddAsync(realEstate);

        return addedRealEstate;
    }

    public async Task<RealEstate> UpdateAsync(RealEstate realEstate)
    {
        RealEstate updatedRealEstate = await _realEstateRepository.UpdateAsync(realEstate);

        return updatedRealEstate;
    }

    public async Task<RealEstate> DeleteAsync(RealEstate realEstate, bool permanent = false)
    {
        RealEstate deletedRealEstate = await _realEstateRepository.DeleteAsync(realEstate);

        return deletedRealEstate;
    }
}

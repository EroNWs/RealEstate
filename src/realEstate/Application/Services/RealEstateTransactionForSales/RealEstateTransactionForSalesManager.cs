using Application.Features.RealEstateTransactionForSales.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RealEstateTransactionForSales;

public class RealEstateTransactionForSalesManager : IRealEstateTransactionForSalesService
{
    private readonly IRealEstateTransactionForSaleRepository _realEstateTransactionForSaleRepository;
    private readonly RealEstateTransactionForSaleBusinessRules _realEstateTransactionForSaleBusinessRules;

    public RealEstateTransactionForSalesManager(IRealEstateTransactionForSaleRepository realEstateTransactionForSaleRepository, RealEstateTransactionForSaleBusinessRules realEstateTransactionForSaleBusinessRules)
    {
        _realEstateTransactionForSaleRepository = realEstateTransactionForSaleRepository;
        _realEstateTransactionForSaleBusinessRules = realEstateTransactionForSaleBusinessRules;
    }

    public async Task<RealEstateTransactionForSale?> GetAsync(
        Expression<Func<RealEstateTransactionForSale, bool>> predicate,
        Func<IQueryable<RealEstateTransactionForSale>, IIncludableQueryable<RealEstateTransactionForSale, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        RealEstateTransactionForSale? realEstateTransactionForSale = await _realEstateTransactionForSaleRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return realEstateTransactionForSale;
    }

    public async Task<IPaginate<RealEstateTransactionForSale>?> GetListAsync(
        Expression<Func<RealEstateTransactionForSale, bool>>? predicate = null,
        Func<IQueryable<RealEstateTransactionForSale>, IOrderedQueryable<RealEstateTransactionForSale>>? orderBy = null,
        Func<IQueryable<RealEstateTransactionForSale>, IIncludableQueryable<RealEstateTransactionForSale, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<RealEstateTransactionForSale> realEstateTransactionForSaleList = await _realEstateTransactionForSaleRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return realEstateTransactionForSaleList;
    }

    public async Task<RealEstateTransactionForSale> AddAsync(RealEstateTransactionForSale realEstateTransactionForSale)
    {
        RealEstateTransactionForSale addedRealEstateTransactionForSale = await _realEstateTransactionForSaleRepository.AddAsync(realEstateTransactionForSale);

        return addedRealEstateTransactionForSale;
    }

    public async Task<RealEstateTransactionForSale> UpdateAsync(RealEstateTransactionForSale realEstateTransactionForSale)
    {
        RealEstateTransactionForSale updatedRealEstateTransactionForSale = await _realEstateTransactionForSaleRepository.UpdateAsync(realEstateTransactionForSale);

        return updatedRealEstateTransactionForSale;
    }

    public async Task<RealEstateTransactionForSale> DeleteAsync(RealEstateTransactionForSale realEstateTransactionForSale, bool permanent = false)
    {
        RealEstateTransactionForSale deletedRealEstateTransactionForSale = await _realEstateTransactionForSaleRepository.DeleteAsync(realEstateTransactionForSale);

        return deletedRealEstateTransactionForSale;
    }
}

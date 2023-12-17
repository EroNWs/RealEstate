using Application.Features.RealEstateTransactionForSales.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.RealEstateTransactionForSales.Rules;

public class RealEstateTransactionForSaleBusinessRules : BaseBusinessRules
{
    private readonly IRealEstateTransactionForSaleRepository _realEstateTransactionForSaleRepository;

    public RealEstateTransactionForSaleBusinessRules(IRealEstateTransactionForSaleRepository realEstateTransactionForSaleRepository)
    {
        _realEstateTransactionForSaleRepository = realEstateTransactionForSaleRepository;
    }

    public Task RealEstateTransactionForSaleShouldExistWhenSelected(RealEstateTransactionForSale? realEstateTransactionForSale)
    {
        if (realEstateTransactionForSale == null)
            throw new BusinessException(RealEstateTransactionForSalesBusinessMessages.RealEstateTransactionForSaleNotExists);
        return Task.CompletedTask;
    }

    public async Task RealEstateTransactionForSaleIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        RealEstateTransactionForSale? realEstateTransactionForSale = await _realEstateTransactionForSaleRepository.GetAsync(
            predicate: retfs => retfs.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RealEstateTransactionForSaleShouldExistWhenSelected(realEstateTransactionForSale);
    }
}
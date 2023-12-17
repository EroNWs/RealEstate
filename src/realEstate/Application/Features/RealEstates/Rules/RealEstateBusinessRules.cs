using Application.Features.RealEstates.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.RealEstates.Rules;

public class RealEstateBusinessRules : BaseBusinessRules
{
    private readonly IRealEstateRepository _realEstateRepository;

    public RealEstateBusinessRules(IRealEstateRepository realEstateRepository)
    {
        _realEstateRepository = realEstateRepository;
    }

    public Task RealEstateShouldExistWhenSelected(RealEstate? realEstate)
    {
        if (realEstate == null)
            throw new BusinessException(RealEstatesBusinessMessages.RealEstateNotExists);
        return Task.CompletedTask;
    }

    public async Task RealEstateIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        RealEstate? realEstate = await _realEstateRepository.GetAsync(
            predicate: re => re.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RealEstateShouldExistWhenSelected(realEstate);
    }
}
using Application.Features.RealEstates.Commands.Create;
using Application.Features.RealEstates.Commands.Delete;
using Application.Features.RealEstates.Commands.Update;
using Application.Features.RealEstates.Queries.GetById;
using Application.Features.RealEstates.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.RealEstates.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<RealEstate, CreateRealEstateCommand>().ReverseMap();
        CreateMap<RealEstate, CreatedRealEstateResponse>().ReverseMap();
        CreateMap<RealEstate, UpdateRealEstateCommand>().ReverseMap();
        CreateMap<RealEstate, UpdatedRealEstateResponse>().ReverseMap();
        CreateMap<RealEstate, DeleteRealEstateCommand>().ReverseMap();
        CreateMap<RealEstate, DeletedRealEstateResponse>().ReverseMap();
        CreateMap<RealEstate, GetByIdRealEstateResponse>().ReverseMap();
        CreateMap<RealEstate, GetListRealEstateListItemDto>().ReverseMap();
        CreateMap<IPaginate<RealEstate>, GetListResponse<GetListRealEstateListItemDto>>().ReverseMap();
    }
}
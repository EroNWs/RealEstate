using Application.Features.RealEstateTransactionForRentals.Commands.Create;
using Application.Features.RealEstateTransactionForRentals.Commands.Delete;
using Application.Features.RealEstateTransactionForRentals.Commands.Update;
using Application.Features.RealEstateTransactionForRentals.Queries.GetById;
using Application.Features.RealEstateTransactionForRentals.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.RealEstateTransactionForRentals.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<RealEstateTransactionForRental, CreateRealEstateTransactionForRentalCommand>().ReverseMap();
        CreateMap<RealEstateTransactionForRental, CreatedRealEstateTransactionForRentalResponse>().ReverseMap();
        CreateMap<RealEstateTransactionForRental, UpdateRealEstateTransactionForRentalCommand>().ReverseMap();
        CreateMap<RealEstateTransactionForRental, UpdatedRealEstateTransactionForRentalResponse>().ReverseMap();
        CreateMap<RealEstateTransactionForRental, DeleteRealEstateTransactionForRentalCommand>().ReverseMap();
        CreateMap<RealEstateTransactionForRental, DeletedRealEstateTransactionForRentalResponse>().ReverseMap();
        CreateMap<RealEstateTransactionForRental, GetByIdRealEstateTransactionForRentalResponse>().ReverseMap();
        CreateMap<RealEstateTransactionForRental, GetListRealEstateTransactionForRentalListItemDto>().ReverseMap();
        CreateMap<IPaginate<RealEstateTransactionForRental>, GetListResponse<GetListRealEstateTransactionForRentalListItemDto>>().ReverseMap();
    }
}
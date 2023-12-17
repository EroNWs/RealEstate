using Application.Features.RealEstateTransactionForSales.Commands.Create;
using Application.Features.RealEstateTransactionForSales.Commands.Delete;
using Application.Features.RealEstateTransactionForSales.Commands.Update;
using Application.Features.RealEstateTransactionForSales.Queries.GetById;
using Application.Features.RealEstateTransactionForSales.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.RealEstateTransactionForSales.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<RealEstateTransactionForSale, CreateRealEstateTransactionForSaleCommand>().ReverseMap();
        CreateMap<RealEstateTransactionForSale, CreatedRealEstateTransactionForSaleResponse>().ReverseMap();
        CreateMap<RealEstateTransactionForSale, UpdateRealEstateTransactionForSaleCommand>().ReverseMap();
        CreateMap<RealEstateTransactionForSale, UpdatedRealEstateTransactionForSaleResponse>().ReverseMap();
        CreateMap<RealEstateTransactionForSale, DeleteRealEstateTransactionForSaleCommand>().ReverseMap();
        CreateMap<RealEstateTransactionForSale, DeletedRealEstateTransactionForSaleResponse>().ReverseMap();
        CreateMap<RealEstateTransactionForSale, GetByIdRealEstateTransactionForSaleResponse>().ReverseMap();
        CreateMap<RealEstateTransactionForSale, GetListRealEstateTransactionForSaleListItemDto>().ReverseMap();
        CreateMap<IPaginate<RealEstateTransactionForSale>, GetListResponse<GetListRealEstateTransactionForSaleListItemDto>>().ReverseMap();
    }
}
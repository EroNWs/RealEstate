using Application.Features.EstateAgents.Commands.Create;
using Application.Features.EstateAgents.Commands.Delete;
using Application.Features.EstateAgents.Commands.Update;
using Application.Features.EstateAgents.Queries.GetById;
using Application.Features.EstateAgents.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.EstateAgents.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<EstateAgent, CreateEstateAgentCommand>().ReverseMap();
        CreateMap<EstateAgent, CreatedEstateAgentResponse>().ReverseMap();
        CreateMap<EstateAgent, UpdateEstateAgentCommand>().ReverseMap();
        CreateMap<EstateAgent, UpdatedEstateAgentResponse>().ReverseMap();
        CreateMap<EstateAgent, DeleteEstateAgentCommand>().ReverseMap();
        CreateMap<EstateAgent, DeletedEstateAgentResponse>().ReverseMap();
        CreateMap<EstateAgent, GetByIdEstateAgentResponse>().ReverseMap();
        CreateMap<EstateAgent, GetListEstateAgentListItemDto>().ReverseMap();
        CreateMap<IPaginate<EstateAgent>, GetListResponse<GetListEstateAgentListItemDto>>().ReverseMap();
    }
}
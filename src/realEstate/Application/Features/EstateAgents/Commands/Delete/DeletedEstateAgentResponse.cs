using Core.Application.Responses;

namespace Application.Features.EstateAgents.Commands.Delete;

public class DeletedEstateAgentResponse : IResponse
{
    public Guid Id { get; set; }
}
using Core.Application.Responses;

namespace Application.Features.EstateAgents.Commands.Update;

public class UpdatedEstateAgentResponse : IResponse
{
    public Guid Id { get; set; }
    public string AgentName { get; set; }
    public string AuthorizedName { get; set; }
    public string AuthorizedSurname { get; set; }
    public string? AuthorizedSecondSurname { get; set; }
    public string? AuthorizedSecondName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string PostalCode { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public byte EmployeeCount { get; set; }
}
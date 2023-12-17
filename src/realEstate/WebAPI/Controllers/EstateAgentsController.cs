using Application.Features.EstateAgents.Commands.Create;
using Application.Features.EstateAgents.Commands.Delete;
using Application.Features.EstateAgents.Commands.Update;
using Application.Features.EstateAgents.Queries.GetById;
using Application.Features.EstateAgents.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EstateAgentsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateEstateAgentCommand createEstateAgentCommand)
    {
        CreatedEstateAgentResponse response = await Mediator.Send(createEstateAgentCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateEstateAgentCommand updateEstateAgentCommand)
    {
        UpdatedEstateAgentResponse response = await Mediator.Send(updateEstateAgentCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedEstateAgentResponse response = await Mediator.Send(new DeleteEstateAgentCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdEstateAgentResponse response = await Mediator.Send(new GetByIdEstateAgentQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListEstateAgentQuery getListEstateAgentQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListEstateAgentListItemDto> response = await Mediator.Send(getListEstateAgentQuery);
        return Ok(response);
    }
}
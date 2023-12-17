using Application.Features.RealEstates.Commands.Create;
using Application.Features.RealEstates.Commands.Delete;
using Application.Features.RealEstates.Commands.Update;
using Application.Features.RealEstates.Queries.GetById;
using Application.Features.RealEstates.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RealEstatesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateRealEstateCommand createRealEstateCommand)
    {
        CreatedRealEstateResponse response = await Mediator.Send(createRealEstateCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRealEstateCommand updateRealEstateCommand)
    {
        UpdatedRealEstateResponse response = await Mediator.Send(updateRealEstateCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedRealEstateResponse response = await Mediator.Send(new DeleteRealEstateCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdRealEstateResponse response = await Mediator.Send(new GetByIdRealEstateQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRealEstateQuery getListRealEstateQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListRealEstateListItemDto> response = await Mediator.Send(getListRealEstateQuery);
        return Ok(response);
    }
}
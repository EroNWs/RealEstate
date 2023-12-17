using Application.Features.RealEstateTransactionForRentals.Commands.Create;
using Application.Features.RealEstateTransactionForRentals.Commands.Delete;
using Application.Features.RealEstateTransactionForRentals.Commands.Update;
using Application.Features.RealEstateTransactionForRentals.Queries.GetById;
using Application.Features.RealEstateTransactionForRentals.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RealEstateTransactionForRentalsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateRealEstateTransactionForRentalCommand createRealEstateTransactionForRentalCommand)
    {
        CreatedRealEstateTransactionForRentalResponse response = await Mediator.Send(createRealEstateTransactionForRentalCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRealEstateTransactionForRentalCommand updateRealEstateTransactionForRentalCommand)
    {
        UpdatedRealEstateTransactionForRentalResponse response = await Mediator.Send(updateRealEstateTransactionForRentalCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedRealEstateTransactionForRentalResponse response = await Mediator.Send(new DeleteRealEstateTransactionForRentalCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdRealEstateTransactionForRentalResponse response = await Mediator.Send(new GetByIdRealEstateTransactionForRentalQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRealEstateTransactionForRentalQuery getListRealEstateTransactionForRentalQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListRealEstateTransactionForRentalListItemDto> response = await Mediator.Send(getListRealEstateTransactionForRentalQuery);
        return Ok(response);
    }
}
using Microsoft.AspNetCore.Mvc;
using RAC.Application.UseCases.Cars.GetAll;
using RAC.Application.UseCases.Cars.GetById;
using RAC.Application.UseCases.Cars.Register;
using RAC.Application.UseCases.Cars.Remove;
using RAC.Application.UseCases.Cars.Update;
using RAC.Communication.Requests;
using RAC.Communication.Responses;
using RAC.Exception.ExceptionBase;

namespace RAC.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{

    [HttpPost]
    [ProducesResponseType(typeof(ResponseCarRegistered), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterCarUseCase useCase,
        [FromBody] RequestCar request)
    {

        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseCarsList), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll([FromServices] IGetAllCarsUseCase useCase)
    {
        var response = await useCase.Execute();

        if(response.CarList.Count == 0)
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(CarInformation), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromServices] IGetCarByIdUseCase useCase, [FromRoute] long id)
    {
        var response = await useCase.Execute(id);
        
        if(response == null)
        {
            return NotFound();
        }
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveCar([FromServices] IRemoveCarUseCase useCase, [FromRoute] long id)
    {
        await useCase.Execute(id);

        return NoContent(); 
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCar([FromServices] IUpdateCarUseCase useCase,
        [FromRoute] long id,
        [FromBody] RequestCar request
        )
    {
        await useCase.Execute(id, request);

        return NoContent();
    }
}

using Microsoft.AspNetCore.Mvc;
using RAC.Application.UseCases.Users.Register;
using RAC.Communication.Requests;
using RAC.Communication.Responses;

namespace RAC.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseUser), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register([FromServices] IRegisterUserUseCase useCase, [FromBody] RequestUser request)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }
}

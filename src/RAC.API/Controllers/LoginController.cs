using Microsoft.AspNetCore.Mvc;
using RAC.Application.UseCases.Login;
using RAC.Communication.Requests;
using RAC.Communication.Responses;

namespace RAC.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class LoginController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseUser), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromServices] ILoginUseCase useCase, [FromBody] RequestLogin request)
    {
        var response = await useCase.Execute(request);

        return Ok(response);
    }
}

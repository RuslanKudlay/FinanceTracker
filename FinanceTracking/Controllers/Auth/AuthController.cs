using BAL.Services.Interfaces;
using DAL.DTOs;
using DAL.DTOs.Auth;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracking.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    [Route("login")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ActionResultDto<AuthResponseDto>),
        StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ActionResultDto<AuthResponseDto>),
        StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ActionResultDto<AuthResponseDto>),
        StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ActionResultDto<AuthResponseDto>),
        StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Login([FromBody] AuthRequestDto dto)
    {
        try
        {
            var token = await _authService.Authorize(dto);
            var data = new AuthResponseDto(token);
            return Ok(new ActionResultDto<AuthResponseDto>()
            {
                Data = data
            });
        }
        catch (Exception e)
        {
            return BadRequest(new ActionResultDto<AuthResponseDto>()
            {
                Message = e.Message
            });
        }
    }
    
}
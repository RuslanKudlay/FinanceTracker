using BAL.Services.Interfaces;
using DAL.DTOs;
using DAL.DTOs.UserSetting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracking.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserSettingController : ControllerBase
{
    private readonly IUserSettingService _userSettingService;

    public UserSettingController(IUserSettingService userSettingService)
    {
        _userSettingService = userSettingService;
    }

    [HttpPost]
    [Route("change-value")]
    [Route("add-member-togroup")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ActionResultDto<bool>),
        StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ActionResultDto<bool>),
        StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ActionResultDto<bool>),
        StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GhangeSettingValue(CreateUserSettingDto dto)
    {
        try
        {
            var result = await _userSettingService.CreateUserSettingAsync(dto);
            return Ok(new ActionResultDto<bool>()
            {
                Data = result
            });
        }
        catch (Exception exception)
        {
            return BadRequest(new ActionResultDto<bool>()
            {
                Message = exception.Message
            });
        }
    }
}
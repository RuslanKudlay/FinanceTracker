using BAL.Services.Base;
using BAL.Services.Interfaces;
using DAL.DTOs;
using DAL.DTOs.Auth;
using DAL.DTOs.FamilyGroup;
using DAL.Entities;
using FinanceTracking.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracking.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class FamilyGroupController : ControllerBase
{
    private readonly IFamilyGroupService _familyGroupService;

    public FamilyGroupController(IFamilyGroupService familyGroupService)
    {
        _familyGroupService = familyGroupService;
    }

    [HttpPost]
    [Route("add-member-togroup")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ActionResultDto<bool>),
        StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ActionResultDto<bool>),
        StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ActionResultDto<bool>),
        StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> AddMember(AddUserToGroupDto dto)
    {
        try
        {
            var result = await _familyGroupService.AddUserToGroupAsync(dto);
            return Ok(new ActionResultDto<bool>()
            {
                Data = result
            });
        }
        catch (Exception e)
        {
            return BadRequest(new ActionResultDto<bool>()
            {
                Message = e.Message
            });
        }
    }
    
    [HttpPost]
    [Route("create-group")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ActionResultDto<bool>),
        StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ActionResultDto<bool>),
        StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ActionResultDto<bool>),
        StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> CreateGroup(CreateGroupDto dto)
    {
        try
        {
            var result = await _familyGroupService.CreateAsync(dto);
            return Ok(new ActionResultDto<bool>()
            {
                Data = result
            });
        }
        catch (Exception e)
        {
            return BadRequest(new ActionResultDto<bool>()
            {
                Message = e.Message
            });
        }
    }
}
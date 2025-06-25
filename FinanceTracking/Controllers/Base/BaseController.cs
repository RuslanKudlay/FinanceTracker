using BAL.Services.Base;
using DAL;
using DAL.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracking.Controllers.Base;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class BaseController<T, D>(IBaseService<T, D> service) : ControllerBase where T : BaseEntity
{
    private readonly IBaseService<T, D> _service = service;

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await service.GetAllASync();
            return Ok(new ActionResultDto<List<D>>
            {
                Data = result,
                Message = string.Empty
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ActionResultDto<List<D>>
            {
                Data = [],
                Message = ex.Message
            });
        }
    }

    [HttpGet]
    [Route("get-by-id")]
    public async Task<IActionResult> GetById([FromQuery] Guid Id)
    {
        try
        {
            var result = await _service.GetByIdAsync(Id);
            return Ok(new ActionResultDto<D>
            {
                Data = result,
                Message = string.Empty
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ActionResultDto<D>
            {
                Message = ex.Message
            });
        }
    }
    
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody] D item)
    {
        try
        {
            var result = await _service.CreateAsync(item);
            return Ok(new ActionResultDto<bool>
            {
                Data = result,
                Message = string.Empty
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ActionResultDto<bool>
            {
                Data = false,
                Message = ex.Message
            });
        }
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> Update([FromBody] D item)
    {
        try
        {
            var result = await _service.UpdateAsync(item);
            return Ok(new ActionResultDto<bool>
            {
                Data = result,
                Message = string.Empty
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ActionResultDto<bool>
            {
                Data = false,
                Message = ex.Message
            });
        }
    }

    [HttpDelete]
    [Route("delete-by-id")]
    public async Task<IActionResult> DeleteById([FromQuery] Guid Id)
    {
        try
        {
            var result = await _service.DeleteAsync(Id);
            return Ok(new ActionResultDto<bool>
            {
                Data = result,
                Message = string.Empty
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ActionResultDto<bool>
            {
                Data = false,
                Message = ex.Message
            });
        }
    }
}
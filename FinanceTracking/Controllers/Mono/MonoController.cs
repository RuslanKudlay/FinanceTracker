using BAL.Services.Interfaces;
using DAL.DTOs;
using DAL.Entities.Mono;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracking.Controllers.Mono;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MonoController : ControllerBase
{
    private readonly IMonoService _monoService;

    public MonoController(IMonoService monoService)
    {
        _monoService = monoService;
    }

    [HttpGet]
    [Route("personal-data")]
    public async Task<IActionResult> GetPersonalData()
    {
        try
        {
            var data = await _monoService.GetBalance();
            return Ok(new ActionResultDto<Client>()
            {
                Data = data
            });
        }
        catch (Exception e)
        {
            return BadRequest(new ActionResultDto<Client>()
            {
                Message = e.Message
            });
        }
    }
}
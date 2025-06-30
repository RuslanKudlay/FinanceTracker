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
    private readonly IClientService _clientService;

    public MonoController(IMonoService monoService, IClientService clientService)
    {
        _monoService = monoService;
        _clientService = clientService;
    }

    [HttpGet]
    [Route("personal-data")]
    public async Task<IActionResult> GetPersonalData()
    {
        try
        {
            var client = await _monoService.GetBalanceAsync();
            await _clientService.CreateOrUpdateClientFromMonoAsync(client);
            
            return Ok(new ActionResultDto<Client>()
            {
                Data = client
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
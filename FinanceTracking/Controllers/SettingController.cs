using BAL.Services.Base;
using BAL.Services.Interfaces;
using DAL.DTOs.Setting;
using DAL.Entities;
using FinanceTracking.Controllers.Base;

namespace FinanceTracking.Controllers;

public class SettingController(ISettingService service) : BaseController<Setting, SettingDto>(service)
{
    
}
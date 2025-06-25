using BAL.Services.Base;
using BAL.Services.Interfaces;
using DAL.DTOs;
using DAL.Entities;
using FinanceTracking.Controllers.Base;

namespace FinanceTracking.Controllers;

public class CetegoryController(ICategoryService service) : BaseController<Category, CategoryDto>(service)
{
    
}
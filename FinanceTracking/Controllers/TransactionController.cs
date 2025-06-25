using BAL.Services.Base;
using DAL.DTOs;
using DAL.Entities;
using FinanceTracking.Controllers.Base;

namespace FinanceTracking.Controllers;

public class TransactionController(IBaseService<Transaction, TransactionDto> service) : BaseController<Transaction, TransactionDto>(service)
{
    
}
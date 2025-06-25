using BAL.Services.Base;
using DAL.DTOs;
using DAL.Entities;

namespace BAL.Services.Interfaces;

public interface ITransactionService : IBaseService<Transaction, TransactionDto>
{
    
}
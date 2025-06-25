using AutoMapper;
using BAL.Services.Base;
using BAL.Services.Interfaces;
using DAL;
using DAL.DTOs;
using DAL.Entities;

namespace BAL.Services;

public class TransactionService : BaseService<Transaction, TransactionDto>, ITransactionService
{
    public TransactionService(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }
}
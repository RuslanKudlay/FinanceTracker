using AutoMapper;
using BAL.Services.Base;
using BAL.Services.Interfaces;
using DAL;
using DAL.DTOs;
using DAL.Entities;

namespace BAL.Services;

public class CategoryService : BaseService<Category, CategoryDto>, ICategoryService
{
    public CategoryService(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }
}
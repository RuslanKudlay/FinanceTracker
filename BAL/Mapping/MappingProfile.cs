using AutoMapper;
using DAL.DTOs;
using DAL.Entities;

namespace DAL.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<Transaction, TransactionDto>().ReverseMap();
    }
}
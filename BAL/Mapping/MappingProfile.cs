using AutoMapper;
using DAL.DTOs;
using DAL.DTOs.Setting;
using DAL.Entities;

namespace DAL.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Transaction, TransactionDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Setting, SettingDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
    }
}
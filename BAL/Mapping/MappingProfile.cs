using AutoMapper;
using DAL.DTOs;
using DAL.DTOs.Mono;
using DAL.DTOs.Setting;
using DAL.Entities;
using DAL.Entities.Mono;

namespace DAL.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Transaction, TransactionDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Setting, SettingDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<Client, ClientDto>().ReverseMap();
        CreateMap<Account, AccountDto>().ReverseMap();
    }
}
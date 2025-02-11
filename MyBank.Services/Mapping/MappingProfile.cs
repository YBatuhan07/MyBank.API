using AutoMapper;
using MyBank.Repository.Accounts;
using MyBank.Services.Accounts;

namespace MyBank.Services.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Account, AccountDto>().ReverseMap();
    }
}

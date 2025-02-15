using AutoMapper;
using MyBank.Repository.Accounts;
using MyBank.Repository.Customers;
using MyBank.Services.Accounts;
using MyBank.Services.Accounts.Create;
using MyBank.Services.Accounts.Update;
using MyBank.Services.Customers;

namespace MyBank.Services.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Account, AccountDto>().ReverseMap();
        CreateMap<CreateAccountRequest, Account>().ForMember(dest => dest.AccountNumber,opt => opt.MapFrom(src => src.AccountNumber.ToLowerInvariant()));
        CreateMap<UpdateAccountRequest,Account>().ForMember(dest => dest.AccountNumber,opt => opt.MapFrom(s => s.AccountNumber.ToLowerInvariant()));
        CreateMap<CreateCustomerRequest, Customer>().ReverseMap();
        CreateMap<CustomerDto, Customer>().ReverseMap();
        CreateMap<CustomerDto, CreateCustomerRequest>().ReverseMap();

    }
}

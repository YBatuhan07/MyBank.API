using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using MyBank.Repository;
using MyBank.Repository.Customers;

namespace MyBank.Services.Customers;

public class CustomerService : ICustomerService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(IUnitOfWork unitOfWork, IMapper mapper, ICustomerRepository customerRepository)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<ServiceResult<CustomerDto>> CreateAsync(CreateCustomerRequest request)
    {
        var customer = _mapper.Map<Customer>(request);

        await _customerRepository.AddAsync(customer);
        await _unitOfWork.SaveChangesAsync();

        var customerDto = _mapper.Map<CustomerDto>(request);

        return ServiceResult<CustomerDto>.Success(customerDto);
    }
    public async Task<ServiceResult<CustomerDto>> GetCustomerWithAccountsAsync(int id)
    {
        var result = await _customerRepository.GetCustomerWithAccountsAsync(id);

        var customerDto = _mapper.Map<CustomerDto>(result);

        return ServiceResult<CustomerDto>.Success(customerDto);
    }
}
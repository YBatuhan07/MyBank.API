using Microsoft.AspNetCore.Mvc;
using MyBank.Services.Customers;

namespace MyBank.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : CustomBaseController
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerRequest request) =>
        CreateActionResult(await _customerService.CreateAsync(request));

    [HttpGet]
    public async Task<IActionResult> Get(int id) =>
        CreateActionResult(await _customerService.GetCustomerWithAccountsAsync(id));
}
using Microsoft.AspNetCore.Mvc;
using MyBank.Services.Accounts;
using MyBank.Services.Accounts.Create;
using MyBank.Services.Accounts.Update;

namespace MyBank.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(AccountService accountService) : CustomBaseController
{
    private readonly AccountService _accountService = accountService;

    [HttpGet]
    public async Task<IActionResult> GetAll() => CreateActionResult(await _accountService.GetAll());

    [HttpGet("{pageNumber:int}/{pageSize:int}")]
    public async Task<IActionResult> GetAll(int pageNumber, int pageSize) => CreateActionResult(await _accountService.GetPagedAllListAsync(pageNumber, pageSize));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAccountById(int id) => CreateActionResult(await _accountService.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> AddAccount(CreateAccountRequest accountDto) => CreateActionResult(await _accountService.CreateAsync(accountDto));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAccount(int id) => CreateActionResult(await _accountService.DeleteAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAccount(int id, UpdateAccountRequest updateAccountRequest) => CreateActionResult(await _accountService.UpdateAsync(id, updateAccountRequest));

    [HttpPatch("balance")]
    public async Task<IActionResult> UpdateBalanceAsync(UpdateAccountBalanceRequest request) => CreateActionResult(await _accountService.UpdateBalanceAsync(request));
}
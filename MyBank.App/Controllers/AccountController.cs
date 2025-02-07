using Microsoft.AspNetCore.Mvc;
using MyBank.Services.Accounts;

namespace MyBank.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(AccountService accountService) : CustomBaseController
{
    private readonly AccountService _accountService = accountService;

    [HttpGet]
    public async Task<IActionResult> GetAll() => CreateActionResult(await _accountService.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAccountById(int id) => CreateActionResult(await _accountService.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> AddAccount(CreateAccountRequest accountDto) => CreateActionResult(await _accountService.CreateAsync(accountDto));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAccount(int id) => CreateActionResult(await _accountService.DeleteAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAccount(int id, UpdateAccountRequest updateAccountRequest) => CreateActionResult(await _accountService.UpdateAsync(id, updateAccountRequest));
}
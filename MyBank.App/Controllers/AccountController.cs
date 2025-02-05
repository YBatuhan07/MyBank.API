using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyBank.Repository.Accounts;
using MyBank.Services;

namespace MyBank.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public IActionResult AddAccount(AccountDto accountDto)
        {
            _accountService.AddAccount(accountDto);
            return Ok();
        }
    }
}

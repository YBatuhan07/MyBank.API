
using MyBank.Services.Accounts.Create;
using MyBank.Services.Accounts.Update;

namespace MyBank.Services.Accounts;

public interface IAccountService
{
    Task<ServiceResult<AccountDto>> GetByIdAsync(int id);

    Task<ServiceResult<CreateAccountResponse>> CreateAsync(CreateAccountRequest createAccountRequest);

    Task<ServiceResult> UpdateAsync(int id, UpdateAccountRequest updateAccountRequest);

    Task<ServiceResult> DeleteAsync(int id);
}
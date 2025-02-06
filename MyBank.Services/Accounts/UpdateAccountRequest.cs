using MyBank.Repository.Enums;

namespace MyBank.Services.Accounts;

public record UpdateAccountRequest(int Id,string AccountNumber, decimal Balance, AccountType AccountType, int CustomerId);

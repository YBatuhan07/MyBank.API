using MyBank.Repository.Enums;

namespace MyBank.Services.Accounts.Create;

public record CreateAccountRequest(string AccountNumber, decimal Balance, AccountType AccountType, int CustomerId);
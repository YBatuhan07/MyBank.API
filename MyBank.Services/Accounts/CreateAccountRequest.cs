using MyBank.Repository.Enums;

namespace MyBank.Services.Accounts;

public record CreateAccountRequest(string AccountNumber, decimal Balance, AccountType AccountType, int CustomerId);
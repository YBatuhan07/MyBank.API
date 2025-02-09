namespace MyBank.Services.Accounts;

public record UpdateAccountBalanceRequest(int AccountId, decimal Balance);

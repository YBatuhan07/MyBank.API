namespace MyBank.Services.Accounts.Update;

public record UpdateAccountBalanceRequest(int AccountId, decimal Balance);

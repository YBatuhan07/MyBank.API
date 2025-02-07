using MyBank.Repository.Customers;
using MyBank.Repository.Enums;
using MyBank.Repository.Transactions;

namespace MyBank.Services.Accounts;

public record AccountDto(int Id, string AccountNumber, decimal Balance, AccountType AccountType, int CustomerId, Customer Customer, ICollection<Transaction> Transactions);



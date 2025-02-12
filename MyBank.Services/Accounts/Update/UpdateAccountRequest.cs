﻿using MyBank.Repository.Enums;

namespace MyBank.Services.Accounts.Update;

public record UpdateAccountRequest(int Id, string AccountNumber, decimal Balance, AccountType AccountType, int CustomerId);

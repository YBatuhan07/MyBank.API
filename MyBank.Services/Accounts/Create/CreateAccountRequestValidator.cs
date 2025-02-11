using FluentValidation;
using MyBank.Repository.Accounts;

namespace MyBank.Services.Accounts.Create;

public class CreateAccountRequestValidator : AbstractValidator<CreateAccountRequest>
{
    private readonly IAccountRepository _accountRepository;

    public CreateAccountRequestValidator(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;

        RuleFor(x => x.Balance)
            .GreaterThanOrEqualTo(0).WithMessage("Hesap eksi bakiye olamaz");

        RuleFor(x => x.CustomerId)
            .GreaterThan(0).WithMessage("Müşteri Id 0 dan büyük olmak zorundadır");

        //RuleFor(x => x.AccountNumber)
        //    .Length(10).Must(MustUniqeAccountNumber).WithMessage("Hesap numarası veritabanında mevcut");
    }

    //private bool MustUniqeAccountNumber(string accountNumber)
    //{
    //    return !_accountRepository.Where(x => x.AccountNumber == accountNumber).Any();
    //}
}
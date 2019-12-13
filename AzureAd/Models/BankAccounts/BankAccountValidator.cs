using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureAd.Models.BankAccounts
{
    public class BankAccountValidator : AbstractValidator<BankAccount>
    {
        public BankAccountValidator()
        {
            RuleFor(account => account.Description).Length(5, 100);
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureAd.Models.Customers
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Name).Length(5, 100).WithMessage("Please enter a valid name");
            RuleFor(customer => customer.PhoneNumber).Must(customer => customer.ToString().Length > 3).WithMessage("Please enter valid phone number");
        }
    }
}

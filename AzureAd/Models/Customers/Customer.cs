using AzureAd.Models.BankAccounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AzureAd.Models.Customers
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public List<BankAccount> Accounts { get; set; }
    }
}

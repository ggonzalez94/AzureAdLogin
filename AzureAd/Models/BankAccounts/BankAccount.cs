using AzureAd.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureAd.Models.BankAccounts
{
    public class BankAccount
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public Currency Currency { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureAd.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public int Number{ get; set; }
        public string Description { get; set; }
        public Currency Currency { get; set; }
        public int CustomerId { get; set; }
    }
}

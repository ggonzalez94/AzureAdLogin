using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AzureAd.Infrastructure;
using AzureAd.Models;

namespace AzureAd.Pages.BankAccounts
{
    public class IndexModel : PageModel
    {
        private readonly AzureAd.Infrastructure.ApplicationDbContext _context;

        public IndexModel(AzureAd.Infrastructure.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<BankAccount> BankAccount { get;set; }

        public async Task OnGetAsync()
        {
            BankAccount = await _context.BankAccounts.ToListAsync();
        }
    }
}
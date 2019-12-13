using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AzureAd.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using AzureAd.Models.BankAccounts;

namespace AzureAd.Pages.BankAccounts
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
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

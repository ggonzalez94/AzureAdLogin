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
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BankAccount BankAccount { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BankAccount = await _context.BankAccounts.FirstOrDefaultAsync(m => m.Id == id);

            if (BankAccount == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BankAccount = await _context.BankAccounts.FindAsync(id);

            if (BankAccount != null)
            {
                _context.BankAccounts.Remove(BankAccount);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

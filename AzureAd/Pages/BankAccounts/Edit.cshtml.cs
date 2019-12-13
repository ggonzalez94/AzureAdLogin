using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AzureAd.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using AzureAd.Models.Customers;
using AzureAd.Models.BankAccounts;

namespace AzureAd.Pages.BankAccounts
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public SelectList CustomerNameList { get; set; }

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
            CustomerNameList = new SelectList(_context.Customers, nameof(Customer.Id), nameof(Customer.Name));
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BankAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankAccountExists(BankAccount.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BankAccountExists(int id)
        {
            return _context.BankAccounts.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AzureAd.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using AzureAd.Models.Customers;
using AzureAd.Models.BankAccounts;

namespace AzureAd.Pages.BankAccounts
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public SelectList CustomerNameList { get; set; }

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            CustomerNameList = new SelectList(_context.Customers, nameof(Customer.Id), nameof(Customer.Name));
            return Page();
        }

        [BindProperty]
        public BankAccount BankAccount { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BankAccounts.Add(BankAccount);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

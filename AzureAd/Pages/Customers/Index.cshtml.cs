using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AzureAd.Infraestructure;
using AzureAd.Models;

namespace AzureAd
{
    public class IndexModel : PageModel
    {
        private readonly AzureAd.Infraestructure.ApplicationDbContext _context;

        public IndexModel(AzureAd.Infraestructure.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers.ToListAsync();
        }
    }
}

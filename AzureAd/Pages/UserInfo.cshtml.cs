using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AzureAd.Pages
{
    public class UserInfoModel : PageModel
    {
        private readonly ILogger<UserInfoModel> _logger;

        public UserInfoModel(ILogger<UserInfoModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}

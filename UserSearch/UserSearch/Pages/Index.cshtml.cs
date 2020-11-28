using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace UserSearch.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly UserManager<IdentityUser> _userManager;

        [BindProperty]
        public List<IdentityUser> UserAccounts { get; set; }

        public IndexModel(UserManager<IdentityUser> userManager, ILogger<IndexModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            UserAccounts = _userManager.Users.ToList();
            return Page();
        }
        public JsonResult OnGetUsers()
        {
            UserAccounts = _userManager.Users.ToList();
            return new JsonResult(UserAccounts);
        }

    }
}
